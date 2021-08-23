using Binarysharp.MemoryManagement;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System;
using Memory;
using System.Drawing;
using System.Collections.Generic;

namespace NightFyre_SOCOM_2
{
    public partial class Main : Form
    {
        Mem _mem = new Mem();
        public static string PROCESSNAME = "pcsx2";
        private static MemorySharp m = new MemorySharp(Process.GetProcessesByName(PROCESSNAME).FirstOrDefault());
        Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation> CodeCave = new Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation>();
        Dictionary<string, IntPtr> ScanResult = new Dictionary<string, IntPtr>();
        Dictionary<string, int> oldData = new Dictionary<string, int>();
        private static IntPtr PLAYEROBJECT = new IntPtr(0x2044D648);
        bool pcsx2Running;
        bool HACKACTIVE = false;
        bool PatternFound = false;
        bool scan1FAIL = false;
        bool scan2FAIL = false;
        bool scan3FAIL = false;
        bool scan4FAIL = false;

        #region MAIN
        public Main()
        {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            debugLabel.Text = "";
            debugAddr1_label.Text = "";
            debugAddr2_label.Text = "";
            debugAddr3_label.Text = "";
            debugAddr4_label.Text = "";
        }

        private void MainClosing(object sender, FormClosingEventArgs e)
        {
            QUIT();
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            Process[] pcsx2 = Process.GetProcessesByName(PROCESSNAME);
            if (pcsx2.Length > 0)
            {
                pcsx2Running = true;
                return;
            }
            pcsx2Running = false;
        }

        private void MemoryTimer_Tick(object sender, EventArgs e)
        {
            if (!pcsx2Running)
            {
                return;
            }

            HACKMAIN();
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            if (pcsx2Running) 
            { 
                if (!PerfectShotCheckBox.Checked) 
                { 
                    if (!HACKACTIVE)
                    {
                        debugLabel.ForeColor = Color.FromArgb(169, 169, 0);
                        debugLabel.Text = "SCANNING .";
                        SCANNER(); 
                    } 
                }
                else
                {
                    debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
                    debugLabel.Text = "Is Checkbox Checked?";
                }
            } 
            else 
            { 
                debugLabel.ForeColor = Color.FromArgb(169, 0, 0);  
                debugLabel.Text = "PCSX2 NOT DETECTED";  
            }
        }

        private void PatchButton_Click(object sender, EventArgs e)
        {
            if (HACKACTIVE)
            {

            }
        }

        private void SCANNER()
        {
            if (!_mem.OpenProcess(PROCESSNAME))
            {
                int PID = _mem.GetProcIdFromName(PROCESSNAME);
                if (PID > 0)
                {
                    _mem.OpenProcess(PID);
                    return;
                }
            }

            if (!PatternFound)
            {
                R1SCAN();
            }

        }

        private void HACKMAIN()
        {
            if (pcsx2Running)
            {
                if (PerfectShotCheckBox.Checked)
                {
                    if (!m.Read<byte>(PLAYEROBJECT, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 }))
                    {
                        if (PatternFound)
                        {
                            if (!HACKACTIVE)
                            {
                                NO_RECOIL1();
                                
                                //So we dont repeat the write
                                HACKACTIVE = true;
                                debugLabel.Text = "SUCCESS";
                            }
                        }
                        else
                        {
                            debugLabel.Text = "SCAN REQUIRED";
                            debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
                        }
                    }
                    else if (HACKACTIVE)
                    {
                        debugLabel.Text = "NOT IN GAME";
                        debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
                        QUIT();
                    }
                }
                else if (HACKACTIVE)
                {
                    debugLabel.Text = "";
                    QUIT();
                }
            }
            else
            {

            }
        }
        #endregion
        
        #region SCANS
        private async void R1SCAN()
        {
            //AoB Scan & Store Result
            IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 40 AA 5C 00 A1 D0 A2 ?? 01", false, true);   //Pattern to search for
            long PatternScanResult = PatternScan.FirstOrDefault();     //Store the result
            if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
            {
                scan1FAIL = true;
                FAIL();
                return;     //We dont want to continue , try again
            }
            string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
            IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
            ScanResult.Add("a", HEXADDR);   //Now we add it to a dictionary
            debugLabel.Text = "SCANNING . .";
            debugAddr1_label.Text = ScanResult["a"].ToString("X");
            R2SCAN();
        }

        private async void R2SCAN()
        {
            //AoB Scan & Store Result
            IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 40 AA 5C 00 83 05 D0 A2 ?? 01 04 E9", false, true);   //Pattern to search for
            long PatternScanResult = PatternScan.FirstOrDefault();     //Store the result
            if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
            {
                scan2FAIL = true;
                FAIL();
                return;     //We dont want to continue , try again
            }
            string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
            IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
            ScanResult.Add("b", HEXADDR);   //Now we add it to a dictionary
            debugLabel.Text = "SCANNING . . .";
            debugAddr2_label.Text = ScanResult["b"].ToString("X");
            S1SCAN();
        }

        private async void S1SCAN()
        {
            //AoB Scan & Store Result
            IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 A8 AB 5C 00 A1 D0 A2 ?? 01 83 C0 0F", false, true);   //Pattern to search for
            long PatternScanResult = PatternScan.FirstOrDefault();     //Store the result
            if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
            {
                scan3FAIL = true;
                FAIL();
                return;     //We dont want to continue , try again
            }
            string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
            IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
            ScanResult.Add("c", HEXADDR);   //Now we add it to a dictionary
            debugLabel.Text = "SCANNING . . . .";
            debugAddr3_label.Text = ScanResult["c"].ToString("X");
            S2SCAN();
        }

        private async void S2SCAN()
        {
            //AoB Scan & Store Result
            IEnumerable<long> PatternScan = await _mem.AoBScan("0F 88 ?? ?? ?? ?? 89 11 8B 0D 30 A0 ?? 01 81 C1 6C 08 00 00 89 C8 C1 E8 0C 8B 04 85 30 ?? ?? ?? BB ?? ?? ?? 30 01 C1 0F 88 ?? ?? ?? D? 8B 01 A3 04 9E EE 01", false, true);   //Pattern to search for
            long PatternScanResult = PatternScan.FirstOrDefault();     //Store the result
            if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
            {
                scan4FAIL = true;
                FAIL();
                return;     //We dont want to continue , try again
            }
            int adjust = (int)PatternScanResult + 0x06;
            string test = adjust.ToString("X");    //We want our Address to be Hex
            IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
            ScanResult.Add("d", HEXADDR);   //Now we add it to a dictionary
            debugLabel.Text = "SCANNING . . . .";
            debugAddr4_label.Text = ScanResult["d"].ToString("X");

            //Done with scans
            debugLabel.Text = "READY";
            debugLabel.ForeColor = Color.FromArgb(0, 169, 0);
            PatternFound = true;    //We are done here
        }

        private async void RFSCAN()
        {
            //AoB Scan & Store Result
            IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 40 AA 5C 00 A1 D0 A2 ?? 01", false, true);   //Pattern to search for
            long PatternScanResult = PatternScan.FirstOrDefault();     //Store the result
            if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
            {
                //scan5FAIL = true;
                FAIL();
                return;     //We dont want to continue , try again
            }
            string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
            IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
            ScanResult.Add("e", HEXADDR);   //Now we add it to a dictionary
            debugLabel.Text = "SCANNING . . . .";
            debugAddr1_label.Text = ScanResult["e"].ToString("X");
        }
        #endregion

        #region HACKS
        private void NO_RECOIL1()
        {
            int ADDRESS = m.Read<int>(ScanResult["a"], false);      //Sometimes it wont be able to read
            oldData.Add("RECOIL1", ADDRESS);
            m.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    ScanResult["a"]);
            NO_RECOIL2();
        }

        private void NO_RECOIL2()
        {
            int ADDRESS = m.Read<int>(ScanResult["b"], false);      //Sometimes it wont be able to read
            oldData.Add("RECOIL2", ADDRESS);
            m.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    ScanResult["b"]);
            NO_SPREAD1();
        }

        private void NO_SPREAD1()
        {
            int ADDRESS = m.Read<int>(ScanResult["c"], false);      //Sometimes it wont be able to read
            oldData.Add("SPREAD1", ADDRESS);
            m.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    ScanResult["c"]);
            NO_SPREAD2();
        }

        private void NO_SPREAD2()
        {
            int ADDRESS = m.Read<int>(ScanResult["d"], false);      //Sometimes it wont be able to read
            oldData.Add("SPREAD2", ADDRESS);
            m.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    ScanResult["d"]);
        }

        private void RAPID_FIRE()
        {
            int ADDRESS = m.Read<int>(ScanResult["e"], false);      //Sometimes it wont be able to read
            oldData.Add("RAPIDFIRE", ADDRESS);
            m.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    ScanResult["e"]);
        }
        #endregion

        #region CLEAN UP
        private void FAIL()
        {
            PatternFound = false;
            debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
            discardDATA();
        }

        private void discardDATA()
        {
            if (scan1FAIL)
            {
                debugAddr1_label.Text = "";
                debugLabel.Text = "ERROR: 1";
                scan1FAIL = false;
            }
            if (scan2FAIL)
            {
                ScanResult.Remove("a");
                debugAddr2_label.Text = "";
                debugLabel.Text = "ERROR: 2";
                scan2FAIL = false;
            }
            if (scan3FAIL)
            {
                ScanResult.Remove("b");
                debugAddr3_label.Text = "";
                debugLabel.Text = "ERROR: 3";
                scan3FAIL = false;
            }
            if (scan4FAIL)
            {
                ScanResult.Remove("c");
                debugAddr4_label.Text = "";
                debugLabel.Text = "ERROR: 4";
                scan3FAIL = false;
            }
        }

        private void QUIT()
        {
            if (HACKACTIVE)
            {
                m.Write<int>(ScanResult["a"], oldData["RECOIL1"], false);
                m.Write<int>(ScanResult["b"], oldData["RECOIL2"], false);
                m.Write<int>(ScanResult["c"], oldData["SPREAD1"], false);
                m.Write<int>(ScanResult["d"], oldData["SPREAD2"], false);
                //m.Write<int>(ScanResult["e"], oldData["RAPIDFIRE"], false);
                ScanResult.Remove("a");
                ScanResult.Remove("b");
                ScanResult.Remove("c");
                ScanResult.Remove("d");
                //ScanResult.Remove("e");
                oldData.Remove("RECOIL1");
                oldData.Remove("RECOIL2");
                oldData.Remove("SPREAD1");
                oldData.Remove("SPREAD2");
                //oldData.Remove("RAPIDFIRE");
                debugLabel.Text = "RE-SCAN REQUIRED";
                debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
                debugAddr1_label.Text = "";
                debugAddr2_label.Text = "";
                debugAddr3_label.Text = "";
                debugAddr4_label.Text = "";
                HACKACTIVE = false;
                PatternFound = false;
            }
        }
        #endregion
    }
}
