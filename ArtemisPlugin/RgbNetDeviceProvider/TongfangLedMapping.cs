using RGB.NET.Core;
using TongFang;
using System.Collections.Generic;

namespace RGB.NET.Devices.Tongfang
{
    public static class TongfangLedMapping
    {
        public static LedMapping<(byte, byte)> ISO { get; } = new()
        {
            [(0, 0)] = LedId.Keyboard_LeftCtrl,
            [(0, 2)] = LedId.Keyboard_Function,
            [(0, 3)] = LedId.Keyboard_LeftGui,
            [(0, 4)] = LedId.Keyboard_LeftAlt,
            [(0, 7)] = LedId.Keyboard_Space,
            [(0, 10)] = LedId.Keyboard_RightAlt,
            [(0, 11)] = LedId.Keyboard_Application,
            [(0, 12)] = LedId.Keyboard_RightCtrl,
            [(0, 13)] = LedId.Keyboard_ArrowLeft,
            [(0, 14)] = LedId.Keyboard_ArrowDown,
            [(0, 15)] = LedId.Keyboard_ArrowRight,
            [(0, 16)] = LedId.Keyboard_Num0,
            [(0, 17)] = LedId.Keyboard_NumPeriodAndDelete,

            [(1, 0)] = LedId.Keyboard_LeftShift,
            [(1, 2)] = LedId.Keyboard_NonUsBackslash,
            [(1, 3)] = LedId.Keyboard_Z,
            [(1, 4)] = LedId.Keyboard_X,
            [(1, 5)] = LedId.Keyboard_C,
            [(1, 6)] = LedId.Keyboard_V,
            [(1, 7)] = LedId.Keyboard_B,
            [(1, 8)] = LedId.Keyboard_N,
            [(1, 9)] = LedId.Keyboard_M,
            [(1, 10)] = LedId.Keyboard_CommaAndLessThan,
            [(1, 11)] = LedId.Keyboard_PeriodAndBiggerThan,
            [(1, 12)] = LedId.Keyboard_SlashAndQuestionMark,
            [(1, 13)] = LedId.Keyboard_RightShift,
            [(1, 14)] = LedId.Keyboard_ArrowUp,
            [(1, 15)] = LedId.Keyboard_Num1,
            [(1, 16)] = LedId.Keyboard_Num2,
            [(1, 17)] = LedId.Keyboard_Num3,
            [(1, 18)] = LedId.Keyboard_NumEnter,

            [(2, 0)] = LedId.Keyboard_CapsLock,
            [(2, 2)] = LedId.Keyboard_A,
            [(2, 3)] = LedId.Keyboard_S,
            [(2, 4)] = LedId.Keyboard_D,
            [(2, 5)] = LedId.Keyboard_F,
            [(2, 6)] = LedId.Keyboard_G,
            [(2, 7)] = LedId.Keyboard_H,
            [(2, 8)] = LedId.Keyboard_J,
            [(2, 9)] = LedId.Keyboard_K,
            [(2, 10)] = LedId.Keyboard_L,
            [(2, 11)] = LedId.Keyboard_SemicolonAndColon,
            [(2, 12)] = LedId.Keyboard_ApostropheAndDoubleQuote,
            [(2, 13)] = LedId.Keyboard_NonUsTilde,
            [(2, 15)] = LedId.Keyboard_Num4,
            [(2, 16)] = LedId.Keyboard_Num5,
            [(2, 17)] = LedId.Keyboard_Num6,

            [(3, 0)] = LedId.Keyboard_Tab,
            [(3, 2)] = LedId.Keyboard_Q,
            [(3, 3)] = LedId.Keyboard_W,
            [(3, 4)] = LedId.Keyboard_E,
            [(3, 5)] = LedId.Keyboard_R,
            [(3, 6)] = LedId.Keyboard_T,
            [(3, 7)] = LedId.Keyboard_Y,
            [(3, 8)] = LedId.Keyboard_U,
            [(3, 9)] = LedId.Keyboard_I,
            [(3, 10)] = LedId.Keyboard_O,
            [(3, 11)] = LedId.Keyboard_P,
            [(3, 12)] = LedId.Keyboard_BracketLeft,
            [(3, 13)] = LedId.Keyboard_BracketRight,
            [(3, 14)] = LedId.Keyboard_Enter,
            [(3, 15)] = LedId.Keyboard_Num7,
            [(3, 16)] = LedId.Keyboard_Num8,
            [(3, 17)] = LedId.Keyboard_Num9,
            [(3, 18)] = LedId.Keyboard_NumPlus,

            [(4, 0)] = LedId.Keyboard_GraveAccentAndTilde,
            [(4, 1)] = LedId.Keyboard_1,
            [(4, 2)] = LedId.Keyboard_2,
            [(4, 3)] = LedId.Keyboard_3,
            [(4, 4)] = LedId.Keyboard_4,
            [(4, 5)] = LedId.Keyboard_5,
            [(4, 6)] = LedId.Keyboard_6,
            [(4, 7)] = LedId.Keyboard_7,
            [(4, 8)] = LedId.Keyboard_8,
            [(4, 9)] = LedId.Keyboard_9,
            [(4, 10)] = LedId.Keyboard_0,
            [(4, 11)] = LedId.Keyboard_MinusAndUnderscore,
            [(4, 12)] = LedId.Keyboard_EqualsAndPlus,
            [(4, 14)] = LedId.Keyboard_Backspace,
            [(4, 15)] = LedId.Keyboard_NumLock,
            [(4, 16)] = LedId.Keyboard_NumSlash,
            [(4, 17)] = LedId.Keyboard_NumAsterisk,
            [(4, 18)] = LedId.Keyboard_NumMinus,

            [(5, 0)] = LedId.Keyboard_Escape,
            [(5, 1)] = LedId.Keyboard_F1,
            [(5, 2)] = LedId.Keyboard_F2,
            [(5, 3)] = LedId.Keyboard_F3,
            [(5, 4)] = LedId.Keyboard_F4,
            [(5, 5)] = LedId.Keyboard_F5,
            [(5, 6)] = LedId.Keyboard_F6,
            [(5, 7)] = LedId.Keyboard_F7,
            [(5, 8)] = LedId.Keyboard_F8,
            [(5, 9)] = LedId.Keyboard_F9,
            [(5, 10)] = LedId.Keyboard_F10,
            [(5, 11)] = LedId.Keyboard_F11,
            [(5, 12)] = LedId.Keyboard_F12,
            [(5, 13)] = LedId.Keyboard_Insert,
            [(5, 14)] = LedId.Keyboard_Delete,
            [(5, 15)] = LedId.Keyboard_Home,
            [(5, 16)] = LedId.Keyboard_End,
            [(5, 17)] = LedId.Keyboard_PageUp,
            [(5, 18)] = LedId.Keyboard_PageDown
        };

        //TODO
        public static LedMapping<(byte, byte)> ANSI { get; } = new()
        {

        };

        public static LedMapping<(byte row, byte column)> GetLayout(KeyboardLayoutType layoutType) => layoutType switch
        {
            KeyboardLayoutType.ISO => ISO,
            _ => ISO
        };
    }
}
