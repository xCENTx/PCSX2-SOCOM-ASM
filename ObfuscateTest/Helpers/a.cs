using Binarysharp.MemoryManagement;
using NightFyre_SOCOM_2;
using System;
using System.Collections.Generic;

namespace DFg3A4j4KuQ574
{
    public partial class jav7372jsd589h
    {
        static Dictionary<string, Binarysharp.MemoryManagement.Memory.RemoteAllocation> _CC = Main._CC;
        static Dictionary<string, IntPtr> _SR = Main._SR;
        static Dictionary<string, int> _OD = Main._OD;
        static MemorySharp _mem = Main.m;

        public static void shn54356Eqtyb2()
        {
            int a = _mem.Read<int>(_SR["a"], false);
            _OD.Add("1", a);
            _mem.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    _SR["a"]);

            int b = _mem.Read<int>(_SR["b"], false);
            _OD.Add("2", b);
            _mem.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    _SR["b"]);
            int c = _mem.Read<int>(_SR["c"], false);
            _OD.Add("3", c);
            _mem.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    _SR["c"]);
            if (Main.TG4hsgDDg433rS)
            {
                return;
            }
            int d = _mem.Read<int>(_SR["d"], false);
            _OD.Add("4", d);
            _mem.Assembly.Inject(
                    new[]
                    {
                    "nop",
                    "nop",
                    },
                    _SR["d"]);
        }
    }
}
