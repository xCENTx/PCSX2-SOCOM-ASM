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
        Mem _mem = new Mem();
        private const string PCSX2PROCESSNAME = "pcsx2";
        private static MemorySharp m = new MemorySharp(Process.GetProcessesByName(PCSX2PROCESSNAME).FirstOrDefault());
        Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation> HolyFuckDude = new Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation>();
        Dictionary<string, IntPtr> ScanResult = new Dictionary<string, IntPtr>();
        Dictionary<string, int> oldData = new Dictionary<string, int>();
        private static IntPtr PLAYEROBJECT = new IntPtr(0x20709D98);
        public static Color GREEN = Color.FromArgb(0, 169, 0);
        bool pcsx2Running = false;
        bool HACKACTIVE = false;
        bool PatternFound = false;
        bool p1FAIL = false;
        bool p2FAIL = false;
        bool p3FAIL = false;
        bool patchRequired = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DEBUG1.Text = "";
            DEBUG2.Text = "";
            DEBUG3.Text = "";
            scan_label.Text = "";
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
            if (!pcsx2Running)
            {
                return;
            }

            if (The_CheckBox.Checked)
            {
                return;
            }

            if (!HACKACTIVE)
            {
                if (!PatternFound)
                {
                    scan_label.ForeColor = Color.FromArgb(169, 169, 0);
                    scan_label.Text = "Searching .";
                    PATTERNSCAN();
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (HACKACTIVE)
            {
                PATCH_RECOIL_SCAN();
            }
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
                    p1FAIL = true;
                    FAIL();
                    return;     //We dont want to continue , try again
                }
                string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
                IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
                ScanResult.Add("a", HEXADDR);   //Now we add it to a dictionary
                scan_label.Text = "Searching . .";
                DEBUG1.Text = ScanResult["a"].ToString("X");
                PATTERNSCAN2();
            }
        }

        //NO SPREAD 2
        public async void PATTERNSCAN2()
        {
            if (!PatternFound)
            {
                //AoB Scan & Store Result
                IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 48 58 49 00 A1 D0 A2 ?? 01 83 C0 04", false, true);   //Pattern to search for
                long PatternScanResult = PatternScan.FirstOrDefault();     //Store the result
                if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
                {
                    p2FAIL = true;
                    FAIL();
                    return;     //We dont want to continue , try again
                }
                string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
                IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
                ScanResult.Add("c", HEXADDR);   //Now we add it to a dictionary
                scan_label.Text = "Searching . . .";
                DEBUG2.Text = ScanResult["c"].ToString("X");
                PATTERNSCAN3();
            }
        }

        //NO RECOIL
        public async void PATTERNSCAN3()
        {
            if (!PatternFound)
            {
                //AoB Scan & Store Result
                IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 8B 15 5C 9E ?? 01 8B 0D 20 A0 ?? 01", false, true);   //Pattern to search for
                long PatternScanResult = PatternScan.FirstOrDefault();    //Store the result
                if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
                {
                    p3FAIL = true;
                    FAIL();
                    return;     //We dont want to continue , try again
                }
                string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
                IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
                ScanResult.Add("d", HEXADDR);   //Now we add it to a dictionary
                DEBUG3.Text = ScanResult["d"].ToString("X");
                //Done with scans
                scan_label.Text = "READY";
                scan_label.ForeColor = Color.FromArgb(0, 169, 0);
                PatternFound = true;    //We are done here
            }
        }

        //No recoil patch
        public async void PATCH_RECOIL_SCAN()
        {
            scan_label.ForeColor = Color.FromArgb(169, 169, 0);
            scan_label.Text = "Patching .";
            //So first thing we should really do ... is revert the previously patched data
            patchRequired = true;
            p3FAIL = true;
            FAIL();

            //AoB Scan & Store Result
            IEnumerable<long> PatternScan = await _mem.AoBScan("89 11 8B 15 5C 9E ?? 01 8B 0D 20 A0 ?? 01", false, true);   //Pattern to search for
            long PatternScanResult = PatternScan.Last();    //Store the result
            if (PatternScanResult == 0)   //If the result is 0 , this means the player did not shoot
            {
                p3FAIL = true;
                FAIL();
                return;     //We dont want to continue , try again
            }
            string test = PatternScanResult.ToString("X");    //We want our Address to be Hex
            IntPtr HEXADDR = new IntPtr(Convert.ToInt32(test, 16));     //We also need it to be an IntPtr
            ScanResult.Add("d", HEXADDR);   //Now we add it to a dictionary
            DEBUG3.Text = ScanResult["d"].ToString("X");
            
            //Done with scans
            scan_label.Text = "READY";
            scan_label.ForeColor = Color.FromArgb(0, 169, 0);
            PatternFound = true;    //We are done here

            if (patchRequired)
            {
                HACK3();
            }
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
                            //HACK1();
                            HACK2();
                            HACK3();

                            //So we dont repeat the write
                            HACKACTIVE = true;
                            PerfectShotPanel.BackColor = Color.FromArgb(0, 169, 0);
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

        //NO SPREAD (DETOUR) //Not using this as its not required (yet)
        private void HACKMAIN()
        {
            //First we need to retrieve the Base Address
            IntPtr BASEADDRESS = new IntPtr((int)ScanResult["a"]);

            //Now we should read the data and store it so we can return things to default later
            int ADDRESS = m.Read<int>(BASEADDRESS, false);
            int ADDRESS2 = m.Read<int>(BASEADDRESS + 0x04, false);
            int ADDRESS3 = m.Read<int>(BASEADDRESS + 0x08, false);
            oldData.Add("1", ADDRESS);
            oldData.Add("2", ADDRESS2);
            oldData.Add("3", ADDRESS3);

            //Find code cave and allocate memory
            var _detour = m.Memory.Allocate(0x4, Binarysharp.MemoryManagement.Native.MemoryProtectionFlags.ExecuteReadWrite, false);
            HolyFuckDude.Add("a", _detour);     //Add this to the dictionary for later

            //Get Address of our code cave
            IntPtr CODECAVEADDRESS = _detour.BaseAddress;
            ScanResult.Add("b", CODECAVEADDRESS);       //Store address to dictionary for later

            //Instructions to write inside our CodeCave
            uint Instruction1 = 0xA1B805C7;
            uint Instruction2 = 0x9078012D;
            int Instruction3 = 0x0049;

            //This is the code inside our code cave
            ///nop
            ///nop
            ///mov [pcsx2.exe+119A1B8],pcsx2.exe+359078
            ///jmp "BaseAddress"
            
            //I really wish this worked for all assembly instructions 
            m.Assembly.Inject(
                    new[]
                    {
                        "nop",
                        "nop",
                    },
                    _detour.BaseAddress);
            
            //Ok now we must do this numbers ...
            m.Write<uint>(CODECAVEADDRESS + 0x02, Instruction1, false);
            m.Write<uint>(CODECAVEADDRESS + 0x06, Instruction2, false);
            m.Write<int>(CODECAVEADDRESS + 0x0A, Instruction3, false);

            //now for the return jump
            var _cave = (int)CODECAVEADDRESS;
            var _base = (int)BASEADDRESS;
            var jmpReturn = (_base - _cave) - 0x05;
            m.Write<int>(CODECAVEADDRESS + 0x0C, 0xE9, false);
            m.Write<int>(CODECAVEADDRESS + 0x0D, jmpReturn, false);

            //Finally we can initiate the jump to our memory region and execute the patched code
            m.Write<int>(ScanResult["a"], 0xE9, false);
            var FinalAct = (_cave - _base) - 0x05;
            m.Write<int>(BASEADDRESS + 0x01, FinalAct, false);
        }

        //No Spread 1
        private void HACK1()
        {
            int ADDRESS = m.Read<int>(ScanResult["a"], false);      //Sometimes it wont be able to read
            oldData.Add("NOSPREAD1", ADDRESS);
            m.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    ScanResult["a"]);
        }

        //NO SPREAD 2
        private void HACK2()
        {
            int ADDRESS = m.Read<int>(ScanResult["c"], false);      //Sometimes it wont be able to read
            oldData.Add("NOSPREAD2", ADDRESS);
            m.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    ScanResult["c"]);
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

            if (patchRequired) 
            {
                PerfectShotPanel.BackColor = Color.FromArgb(0, 169, 0);
                scan_label.Text = "SUCCESS";
                patchRequired = false; 
            }
        }

        private void FAIL()
        {
            if (patchRequired)
            {
                DISCARD_DATA();
                return;
            }
            PatternFound = false;
            scan_label.ForeColor = Color.FromArgb(169, 0, 0);
            DISCARD_DATA();
        }

        private void DISCARD_DATA()
        {
            if (p1FAIL)
            {
                ScanResult.Remove("a");
                scan_label.Text = "ERROR: SHOOT";
                DEBUG1.Text = "";
                p1FAIL = false;
            }
            if (p2FAIL)
            {
                ScanResult.Remove("a");
                p2FAIL = false;
                DEBUG2.Text = "";
                scan_label.Text = "ERROR: MOVE";
            }
            if (p3FAIL)
            {
                if (patchRequired)
                {
                    DEBUG3.Text = "";
                    scan_label.Text = "Patching . .";
                    m.Write<int>(ScanResult["d"], oldData["NORECOIL"], false);
                    oldData.Remove("NORECOIL");
                    ScanResult.Remove("d");
                    p3FAIL = false;
                    return;
                }
                ScanResult.Remove("c");
                p3FAIL = false;
                DEBUG3.Text = "";
                scan_label.Text = "ERROR: SHOOT";
            }
        }

        private void QUIT()
        {
            if (HACKACTIVE)
            {
                //Write Default to HACKMAIN
                m.Write<int>(ScanResult["a"], oldData["1"], false);
                m.Write<int>(ScanResult["a"] + 0x04, oldData["2"], false);
                m.Write<int>(ScanResult["a"] + 0x08, oldData["3"], false);
                // Code Cave stuff
                m.Memory.Deallocate(HolyFuckDude["a"]);
                HolyFuckDude.Remove("a");
                ScanResult.Remove("b");
                oldData.Remove("1");
                oldData.Remove("2");
                oldData.Remove("3");

                //Write Default no spread 1
                m.Write<int>(ScanResult["a"], oldData["NOSPREAD1"], false);
                
                //Write default no spread 2
                m.Write<int>(ScanResult["c"], oldData["NOSPREAD2"], false);
                
                //write default no recoil
                //m.Write<int>(ScanResult["d"], oldData["NORECOIL"], false);


                ScanResult.Remove("a");
                ScanResult.Remove("c");
                //ScanResult.Remove("d");
                //oldData.Remove("NORECOIL");
                oldData.Remove("NOSPREAD1");
                oldData.Remove("NOSPREAD2");
                scan_label.Text = "RE-SCAN REQUIRED";
                scan_label.ForeColor = Color.FromArgb(169, 0, 0);
                DEBUG1.Text = "";
                DEBUG2.Text = "";
                DEBUG3.Text = "";
                HACKACTIVE = false;
                PatternFound = false;
            }
        }

    }
}
