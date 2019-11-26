using System;
using System.Collections.Generic;
using System.Text;

namespace TongFang
{
    public enum Effect : byte
    {
        Static = 1,
        Breathing = 2,
        Wave = 3,
        Reactive = 4,
        Rainbow = 5,
        Ripple = 6,
        Nomo = 8,
        Marquee = 9,
        Raindrop = 10,
        Stack = 12,
        Impact = 13,
        Aurora = 14,
        Neon = 15,
        Spark = 17,
        Flash = 18,
        Mix = 19,
        Music = 34,
        UserMode = 51,
        Unknown = 255
    }

    public enum EffecType : byte
    {
        FW = 0,
        ROW = 1,
        PICTURE = 2,
        MUSIC = 3,
        AP = 4
    }

    public enum Control : byte
    {
        Off = 1,
        Default = 2,
        Welcome = 3
    }

    public enum Key : byte//weird math is col + ((5 - row) * 21)
    {
        //0,0
        LCtrl = 105,

        //0,1 blank

        //0,2
        LFn = 107,

        //0,3
        LWin = 108,

        //0,4
        LAlt = 109,

        //0,5 blank
        //0,6 blank

        //0,7
        Space = 112,

        //0,8 blank
        //0,9 blank

        //0,10
        RAlt = 115,

        //0,11
        Menu = 116,

        //0,12
        RCtrl = 117,

        //0,13
        Left = 118,

        //0,14
        Down = 119,

        //0,15
        Right = 120
    }
}
