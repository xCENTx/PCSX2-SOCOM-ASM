using System.Collections.Generic;
using NightFyre_SOCOM_2;
using System.Drawing;
using System.Linq;
using System;
using Memory;

namespace sd2f16WET7B652
{
    public partial class adfh65hj4dft83
    {
        static Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation> _CC = Main._CC;
        public static IntPtr ASDG1654ec4rc6 = new IntPtr(541382216);
        static Dictionary<string, IntPtr> _SR = Main._SR;
        static Mem _mem = Main._mem;

        public static async void shn54356Eqtyb2()
        {
            IEnumerable<long> ps1 = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 40 AA 5C 00 A1 D0 A2 ?? 01", false, true);
            long psr1 = ps1.FirstOrDefault();
            if (psr1 == 0)
            {
                Main.df34A5G7F4d4ge = true;
                Main.pas08fywr8325j();
                return;
            }
            string D1 = psr1.ToString("X");
            IntPtr H1 = new IntPtr(Convert.ToInt32(D1, 16));
            _SR.Add("a", H1);
            Main.debugLabel.Text = "SCANNING . .";
            Main.debugAddr1_label.Text = _SR["a"].ToString("X");

            IEnumerable<long> ps2 = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 40 AA 5C 00 83 05 D0 A2 ?? 01 04 E9", false, true);
            long psr2 = ps2.FirstOrDefault();
            if (psr2 == 0)
            {
                Main.e4dghjk357gD7r = true;
                Main.pas08fywr8325j();
                return;
            }
            string D2 = psr2.ToString("X");
            IntPtr H2 = new IntPtr(Convert.ToInt32(D2, 16));
            _SR.Add("b", H2);
            Main.debugLabel.Text = "SCANNING . . .";
            Main.debugAddr2_label.Text = _SR["b"].ToString("X");

            IEnumerable<long> ps3 = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 A8 AB 5C 00 A1 D0 A2 ?? 01 83 C0 0F", false, true);
            long psr3 = ps3.FirstOrDefault();
            if (psr3 == 0)
            {
                Main.f27S867TGRT1Jq = true;
                Main.pas08fywr8325j();
                return;
            }
            string D3 = psr3.ToString("X");
            IntPtr H3 = new IntPtr(Convert.ToInt32(D3, 16));
            _SR.Add("c", H3);
            Main.debugLabel.Text = "SCANNING . . . .";
            Main.debugAddr3_label.Text = _SR["c"].ToString("X");

            IEnumerable<long> ps4 = await _mem.AoBScan("0F ?? ?? ?? ?? D2 89 11 8B 0D 30 A0 ?? " +
                    "01 81 C1 6C 08 00 00 89 C8 C1 E8 " +
                    "0C 8B 04 85 30 ?? ?? ?? BB ?? ?? " +
                    "?? 30 01 C1 0F 88 ?? ?? ?? D2 8B " +
                    "01 A3 04 9E ?? 01", false, true);
            long psr4 = ps4.FirstOrDefault();
            if (psr4 == 0)
            {
                Main.ag8kt75adgfh35();
            }
            int a = (int)psr4 + 0x06;
            string D4 = a.ToString("X");
            IntPtr H4 = new IntPtr(Convert.ToInt32(D4, 16));
            _SR.Add("d", H4);
            Main.debugLabel.Text = "SCANNING . . . .";
            Main.debugAddr4_label.Text = _SR["d"].ToString("X");
            Main.debugLabel.Text = "READY";
            Main.debugLabel.ForeColor = Color.FromArgb(0, 169, 0);
            Main.H41Gw6fgh3456g = true;
        }

        public static async void ouAhdhFG945625()
        {
            IEnumerable<long> agaerHUAVG = await _mem.AoBScan("89 11 C7 05 B8 A1 ?? 01 40 AA 5C 00 A1 D0 A2 ?? 01", false, true);
            long mKLFNJVHhjhdlajfgh = agaerHUAVG.FirstOrDefault();
            if (mKLFNJVHhjhdlajfgh == 0)
            {
                Main.nr87hazdfh85uj = true;
                Main.pas08fywr8325j();
                return;
            }
            string mkvdfanjgh = mKLFNJVHhjhdlajfgh.ToString("X");
            IntPtr HDFAJHueyqwr = new IntPtr(Convert.ToInt32(mkvdfanjgh, 16));
            _SR.Add("e", HDFAJHueyqwr);
            Main.debugLabel.Text = "SCANNING . . . .";
            Main.debugAddr1_label.Text = _SR["e"].ToString("X");
        }
    }
}
