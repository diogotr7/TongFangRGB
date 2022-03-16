using System;
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

    public enum Layout
    {
        ISO,
        ANSI
    }
}
