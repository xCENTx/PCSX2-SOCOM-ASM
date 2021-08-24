using Binarysharp.MemoryManagement;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using DFg3A4j4KuQ574;
using sd2f16WET7B652;
using System;
using Memory;

namespace NightFyre_SOCOM_2
{
    public partial class Main : Form
    {
        public static Mem _mem = new Mem();
        public static string d20MMSV098E5V0 = "pcsx2";
        public static MemorySharp m = new MemorySharp(Process.GetProcessesByName(d20MMSV098E5V0).First());
        public static Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation> _CC = new Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation>();
        public static Dictionary<string, IntPtr> _SR = new Dictionary<string, IntPtr>();
        public static Dictionary<string, int> _OD = new Dictionary<string, int>();
        public static bool bJSD476T1YHNSI;
        public static bool u5a4sdg56agoa7 = false;
        public static bool H41Gw6fgh3456g = false;
        public static bool df34A5G7F4d4ge = false;
        public static bool e4dghjk357gD7r = false;
        public static bool f27S867TGRT1Jq = false;
        public static bool F1s54fg865ah4z = false;
        public static bool nr87hazdfh85uj = false;
        public static bool TG4hsgDDg433rS = false;

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
            fi9385kjaf9038();
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            Process[] pcsx2 = Process.GetProcessesByName(d20MMSV098E5V0);
            if (pcsx2.Length > 0)
            {
                bJSD476T1YHNSI = true;
                return;
            }
            debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
            debugLabel.Text = "PCSX2 NOT DETECTED";
            bJSD476T1YHNSI = false;
            fi9385kjaf9038();
        }

        private void MemoryTimer_Tick(object sender, EventArgs e)
        {
            if (!bJSD476T1YHNSI)
            {
                return;
            }

            uQWE8902385RVK();
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            if (bJSD476T1YHNSI) 
            { 
                if (!PerfectShotCheckBox.Checked) 
                { 
                    if ((!u5a4sdg56agoa7) && (!H41Gw6fgh3456g))
                    {
                        debugLabel.ForeColor = Color.FromArgb(169, 169, 0);
                        debugLabel.Text = "SCANNING .";
                        hav457e5bvSHFG(); 
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
            if (u5a4sdg56agoa7)
            {

            }
        }

        private void hav457e5bvSHFG()
        {
            if (!_mem.OpenProcess(d20MMSV098E5V0))
            {
                int PID = _mem.GetProcIdFromName(d20MMSV098E5V0);
                if (PID > 0)
                {
                    _mem.OpenProcess(PID);
                    return;
                }
            }

            if (!H41Gw6fgh3456g)
            {
                adfh65hj4dft83.shn54356Eqtyb2();
            }
        }

        private void uQWE8902385RVK()
        {
            if (bJSD476T1YHNSI)
            {
                if (PerfectShotCheckBox.Checked)
                {
                    if (H41Gw6fgh3456g)
                    {
                        if (!m.Read<byte>(adfh65hj4dft83.ASDG1654ec4rc6, 4, false).SequenceEqual(new byte[] { 0, 0, 0, 0 }))
                        {
                            if (!u5a4sdg56agoa7)
                            {
                                jav7372jsd589h.shn54356Eqtyb2();
                                u5a4sdg56agoa7 = true;
                                debugLabel.Text = "SUCCESS";
                                if (TG4hsgDDg433rS)
                                {
                                    debugLabel.Text = "LIMP MODE";
                                    debugLabel.ForeColor = Color.FromArgb(169, 169, 0);
                                }
                            }
                        }
                        else if (u5a4sdg56agoa7)
                        {
                            debugLabel.Text = "NOT IN GAME";
                            debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
                            fi9385kjaf9038();
                        }
                    }
                    else
                    {
                        debugLabel.Text = "SCAN REQUIRED";
                        debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
                    }
                }
                else if (u5a4sdg56agoa7)
                {
                    debugLabel.Text = "";
                    fi9385kjaf9038();
                }
            }
            else
            {
                pas08fywr8325j();
            }
        }

        public static void ag8kt75adgfh35()
        {
            F1s54fg865ah4z = true;
            var ERROR = MessageBox.Show("LIMP MODE?", "ERROR: 4", MessageBoxButtons.YesNo);
            if (ERROR == DialogResult.Yes)
            {
                TG4hsgDDg433rS = true;
                H41Gw6fgh3456g = true;
                return;
            }
            else
            {
                pas08fywr8325j();
                return;
            }
        }

        public static void pas08fywr8325j()
        {
            H41Gw6fgh3456g = false;
            debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
            yus93ghs95sdh8();
        }

        public static void yus93ghs95sdh8()
        {
            if (df34A5G7F4d4ge)
            {
                debugAddr1_label.Text = "";
                debugLabel.Text = "ERROR: 1";
                df34A5G7F4d4ge = false;
            }
            if (e4dghjk357gD7r)
            {
                _SR.Remove("a");
                debugAddr2_label.Text = "";
                debugLabel.Text = "ERROR: 2";
                e4dghjk357gD7r = false;
            }
            if (f27S867TGRT1Jq)
            {
                _SR.Remove("a");
                _SR.Remove("b");
                debugAddr3_label.Text = "";
                debugLabel.Text = "ERROR: 3";
                f27S867TGRT1Jq = false;
            }
            if (F1s54fg865ah4z)
            {
                _SR.Remove("a");
                _SR.Remove("b");
                _SR.Remove("c");
                debugAddr4_label.Text = "";
                debugLabel.Text = "ERROR: 4";
                F1s54fg865ah4z = false;
            }
            if (!bJSD476T1YHNSI)
            {
                if (u5a4sdg56agoa7)
                {
                    //m.Write<int>(_SR["e"], _OD["5"], false);
                    _SR.Remove("a");
                    _SR.Remove("b");
                    _SR.Remove("c");
                    _SR.Remove("d");
                    //_SR.Remove("e");
                    _OD.Remove("1");
                    _OD.Remove("2");
                    _OD.Remove("3");
                    _OD.Remove("4");
                    //_OD.Remove("5");
                    debugLabel.Text = "PCSX2 NOT DETECTED";
                    debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
                    debugAddr1_label.Text = "";
                    debugAddr2_label.Text = "";
                    debugAddr3_label.Text = "";
                    debugAddr4_label.Text = "";
                    u5a4sdg56agoa7 = false;
                    H41Gw6fgh3456g = false;
                }
            }
        }

        private void fi9385kjaf9038()
        {
            if ((u5a4sdg56agoa7) && (!TG4hsgDDg433rS))
            {
                m.Write<int>(_SR["a"], _OD["1"], false);
                m.Write<int>(_SR["b"], _OD["2"], false);
                m.Write<int>(_SR["c"], _OD["3"], false);
                m.Write<int>(_SR["d"], _OD["4"], false);
                //m.Write<int>(_SR["e"], _OD["5"], false);
                _SR.Remove("a");
                _SR.Remove("b");
                _SR.Remove("c");
                _SR.Remove("d");
                //_SR.Remove("e");
                _OD.Remove("1");
                _OD.Remove("2");
                _OD.Remove("3");
                _OD.Remove("4");
                //_OD.Remove("5");
                debugLabel.Text = "RE-SCAN REQUIRED";
                debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
                debugAddr1_label.Text = "";
                debugAddr2_label.Text = "";
                debugAddr3_label.Text = "";
                debugAddr4_label.Text = "";
                u5a4sdg56agoa7 = false;
                H41Gw6fgh3456g = false;
            }
            else if (TG4hsgDDg433rS)
            {
                m.Write<int>(_SR["a"], _OD["1"], false);
                m.Write<int>(_SR["b"], _OD["2"], false);
                m.Write<int>(_SR["c"], _OD["3"], false);
                _SR.Remove("a");
                _SR.Remove("b");
                _SR.Remove("c");
                _OD.Remove("1");
                _OD.Remove("2");
                _OD.Remove("3");
                debugLabel.Text = "RE-SCAN REQUIRED";
                debugLabel.ForeColor = Color.FromArgb(169, 0, 0);
                debugAddr1_label.Text = "";
                debugAddr2_label.Text = "";
                debugAddr3_label.Text = "";
                debugAddr4_label.Text = "";
                u5a4sdg56agoa7 = false;
                H41Gw6fgh3456g = false;
                TG4hsgDDg433rS = false;
            }
        }
        #endregion
    }
}
