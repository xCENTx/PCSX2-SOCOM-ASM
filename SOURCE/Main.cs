using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using Binarysharp.MemoryManagement;
using Memory;


/// Created by: NightFyreTV
/// Platform: PCSX2 v1.6.0
/// Game: SOCOM: Combined Assault v2.3

namespace PCSX2_ASM
{
    public partial class Main : Form
    {
        private const string PCSX2PROCESSNAME = "pcsx2";
        Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation> HolyFuckDude = new Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation>();
        Dictionary<string, IntPtr> ScanResult = new Dictionary<string, IntPtr>();
        Dictionary<string, int> oldData = new Dictionary<string, int>();
        private static IntPtr PLAYEROBJECT = new IntPtr(0x20709D98);
        private static MemorySharp m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).FirstOrDefault());
        bool pcsx2Running = false;
        bool HACKACTIVE = false;
        bool PatternFound = false;
        Mem _mem = new Mem();

        public Main()
        {
            InitializeComponent();
            scan_label.Text = "SCAN REQUIRED";
            scan_label.ForeColor = Color.FromArgb(169, 169, 0);
        }
        
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            QUIT();
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            Process[] pcsx2 = Process.GetProcessesByName(PCSX2PROCESSNAME);
            if (pcsx2.Length > 0)
            {
                pcsx2Running = true;
                return;
            }
            pcsx2Running = false;
        }

        private void MemoryTimer_Tick(object sender, EventArgs e)
        {
            ASSEMBLYHACK();
        }
        
        private void SCAN_BUTTON_Click(object sender, EventArgs e)
        {
            scan_label.Text = "Searching . . . .";
            scan_label.ForeColor = Color.FromArgb(169, 169, 0);
            PATTERNSCAN();
            PATTERNSCAN2();
            PATTERNSCAN3();
        }

        //ASM HACK Scan
        public async void PATTERNSCAN()
        {
            if (!_mem.OpenProcess(PCSX2PROCESSNAME))
            {
                int PID = _mem.GetProcIdFromName(PCSX2PROCESSNAME);
                if (PID > 0)
                {
                    _mem.OpenProcess(PID);
                    return;
                }
            }

            if (!PatternFound)
            {
                //AoB Scan & Store Result
                IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 78 60 49 00 A1 D0 A2 ?? 01", false, true);   //Pattern to search for
                long PatternScanResult = PatternScan.FirstOrDefault();     //Store the result
                if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
                {
                    //We want to notifiy the user that they need to shoot firt and that it is not working
                    MessageBox.Show("Failed, Please try again. You must shoot gun first");
                    PatternFound = false;
                    scan_label.Text = "FAILED";
                    scan_label.ForeColor = Color.FromArgb(169, 0, 0);
                    return;     //We dont want to continue , try again
                }
                string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
                IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
                ScanResult.Add("a", HEXADDR);   //Now we add it to a dictionary
            }
        }

        //NO SPREAD 2
        public async void PATTERNSCAN2()
        {
            //AoB Scan & Store Result
            IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 48 58 49 00 A1 D0 A2 ?? 01 83 C0 04", false, true);   //Pattern to search for
            long PatternScanResult = PatternScan.FirstOrDefault();     //Store the result
            if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
            {
                //We want to notifiy the user that they need to shoot firt and that it is not working
                MessageBox.Show("Failed, Please try again. You must shoot gun first");
                PatternFound = false;
                scan_label.Text = "FAILED";
                scan_label.ForeColor = Color.FromArgb(169, 0, 0);
                return;     //We dont want to continue , try again
            }
            string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
            IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
            ScanResult.Add("c", HEXADDR);   //Now we add it to a dictionary
        }

        //NO RECOIL
        public async void PATTERNSCAN3()
        {
            //AoB Scan & Store Result
            IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 8B 15 5C 9E ?? 01 8B 0D 20 A0 ?? 01", false, true);   //Pattern to search for
            long PatternScanResult = PatternScan.FirstOrDefault();     //Store the result
            if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
            {
                //We want to notifiy the user that they need to shoot firt and that it is not working
                MessageBox.Show("Failed, Please try again. You must shoot gun first");
                PatternFound = false;
                scan_label.Text = "FAILED";
                scan_label.ForeColor = Color.FromArgb(169, 0, 0);
                return;     //We dont want to continue , try again
            }
            string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
            IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
            ScanResult.Add("d", HEXADDR);   //Now we add it to a dictionary

            //Done with scans
            scan_label.Text = "READY";
            scan_label.ForeColor = Color.FromArgb(0, 169, 0);
            PatternFound = true;    //We are done here
        }

        private void ASSEMBLYHACK()
        {
            if (!pcsx2Running)
            {
                return;
            }

            if (The_CheckBox.Checked)
            {
                //Is the player in game?
                if (!m.Read<byte>(PLAYEROBJECT, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 }))
                {
                    //Have we found the pattern?
                    if (PatternFound)
                    {
                        //We only want to perform this once per press of the checkbox
                        if (!HACKACTIVE)
                        {
                            HACKMAIN();
                            HACK2();
                            HACK3();

                            //So we dont repeat the write
                            HACKACTIVE = true;
                            scan_label.Text = "SUCCESS";
                        }
                    }
                    else
                    {
                        scan_label.Text = "SCAN REQUIRED";
                        scan_label.ForeColor = Color.FromArgb(169, 0, 0);
                    }
                }
                else if (HACKACTIVE)
                {
                    QUIT();
                }
            }
            else if (HACKACTIVE)
            {
                QUIT();
            }
        }

        //NO SPREAD (DETOUR)
        private void HACKMAIN()
        {
            //First we need to retrieve the Base Address
            IntPtr BASEADDRESS = new IntPtr((int)ScanResult["a"]);

            //Lets read some data
            int ADDRESS = m.Read<int>(BASEADDRESS, false);      //Sometimes it wont be able to read
            int ADDRESS2 = m.Read<int>(BASEADDRESS + 0x04, false);
            int ADDRESS3 = m.Read<int>(BASEADDRESS + 0x08, false);
            oldData.Add("1", ADDRESS);
            oldData.Add("2", ADDRESS2);
            oldData.Add("3", ADDRESS3);

            //Find code cave and allocate memory
            var _detour = m.Memory.Allocate(0x4, Binarysharp.MemoryManagement.Native.MemoryProtectionFlags.ExecuteReadWrite, false);
            HolyFuckDude.Add("a", _detour);

            //Get Address of our code cave
            IntPtr CODECAVEADDRESS = _detour.BaseAddress;
            ScanResult.Add("b", CODECAVEADDRESS);       //Store address to dictionary for later

            //Instructions to write inside our CodeCave
            uint Instruction1 = 0xA1B805C7;
            uint Instruction2 = 0x9078012D;
            int Instruction3 = 0x0049;

            //Assembly Code
            m.Assembly.Inject(
                    new[]
                    {
                                    "nop",
                                    "nop",
                    },
                    _detour.BaseAddress);
            m.Write<uint>(CODECAVEADDRESS + 0x02, Instruction1, false);
            m.Write<uint>(CODECAVEADDRESS + 0x06, Instruction2, false);
            m.Write<int>(CODECAVEADDRESS + 0x0A, Instruction3, false);
            var _cave = (int)CODECAVEADDRESS;
            var _base = (int)BASEADDRESS;
            var jmpReturn = (_base - _cave) - 0x05;
            m.Write<int>(CODECAVEADDRESS + 0x0C, 0xE9, false);
            m.Write<int>(CODECAVEADDRESS + 0x0D, jmpReturn, false);
            m.Write<int>(ScanResult["a"], 0xE9, false);
            var FinalAct = (_cave - _base) - 0x05;
            m.Write<int>(BASEADDRESS + 0x01, FinalAct, false);
        }

        //NO SPREAD 2
        private void HACK2()
        {
            IntPtr BASEADDRESS = new IntPtr((int)ScanResult["c"]);
            int ADDRESS = m.Read<int>(BASEADDRESS, false);      //Sometimes it wont be able to read
            oldData.Add("NOSPREAD2", ADDRESS);
            m.Assembly.Inject(
                    new[]
                    {
                                    "nop",
                                    "nop",
                    },
                    BASEADDRESS);
        }

        //NO RECOIL
        private void HACK3()
        {
            IntPtr BASEADDRESS = new IntPtr((int)ScanResult["d"]);
            int ADDRESS = m.Read<int>(BASEADDRESS, false);      //Sometimes it wont be able to read
            oldData.Add("NORECOIL", ADDRESS);
            m.Assembly.Inject(
                    new[]
                    {
                                    "nop",
                                    "nop",
                    },
                    BASEADDRESS);
        }

        private void QUIT()
        {
            if (HACKACTIVE)
            {
                //ASM HACK
                int oldData1 = oldData["1"];
                int oldData2 = oldData["2"];
                int oldData3 = oldData["3"];
                var _detour = HolyFuckDude["a"];
                IntPtr BASEADDRESS = new IntPtr((int)ScanResult["a"]);
                m.Write<int>(BASEADDRESS, oldData1, false);
                m.Write<int>(BASEADDRESS + 0x04, oldData2, false);
                m.Write<int>(BASEADDRESS + 0x08, oldData3, false);
                m.Memory.Deallocate(_detour);
                HolyFuckDude.Remove("a");
                ScanResult.Remove("a");
                ScanResult.Remove("b");
                oldData.Remove("1");
                oldData.Remove("2");
                oldData.Remove("3");

                //NO SPREAD 2
                int oldData4 = oldData["NOSPREAD2"];
                IntPtr BASEADDRESS2 = new IntPtr((int)ScanResult["c"]);
                m.Write<int>(BASEADDRESS2, oldData4, false);
                ScanResult.Remove("c");
                oldData.Remove("NOSPREAD2");
                
                //NO RECOIL
                int oldData5 = oldData["NORECOIL"];
                IntPtr BASEADDRESS3 = new IntPtr((int)ScanResult["d"]);
                m.Write<int>(BASEADDRESS3, oldData5, false);
                ScanResult.Remove("d");
                oldData.Remove("NORECOIL");

                //Labels and Bools
                scan_label.Text = "RE-SCAN REQUIRED";
                scan_label.ForeColor = Color.FromArgb(169, 0, 0);
                HACKACTIVE = false;
                PatternFound = false;
            }
        }

    }
}
