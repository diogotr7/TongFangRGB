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

    //This is for ANSI
    public enum Key : byte//weird math is col + ((5 - row) * 21)
    {
        //0,0
        LEFT_CONTROL = 105,

        //0,1 blank

        //0,2
        FN_Key = 107,

        //0,3
        LEFT_WINDOWS = 108,

        //0,4
        LEFT_ALT = 109,

        //0,5 blank
        //0,6 blank

        //0,7
        SPACE = 112,

        //0,8 blank
        //0,9 blank

        //0,10
        RIGHT_ALT = 115,

        //0,11
        MENU = 116,

        //0,12
        RIGHT_CONTROL = 117,

        //0,13
        ARROW_LEFT = 118,

        //0,14
        DOWN_ARROW = 119,

        //0,15
        RIGHT_ARROW = 120,

        //0,16 blank

        //0,17 blank

        //0,18 blank

        //0,19 blank

        //0,20 blank

        //1,0 blank

        //1,1
        LEFT_SHIFT = 85,

        //1,2 blank

        //1,3
        Z = 87,

        //1,4 
        X = 88,

        //1,5
        C = 89,

        //1,6
        V = 90,

        //1,7
        B = 91,

        //1,8
        N = 92,

        //1,9
        M = 93,

        //1,10
        COMMA = 94,

        //1,11
        PERIOD = 95,

        //1,12
        FORWARD_SLASH = 96,

        //1,13
        RIGHT_SHIFT = 97,

        //1,14
        UP_ARROW = 98,

        //1,15
        END = 99,

        //1,16 blank

        //1,17 blank

        //1,18 blank

        //1,19 blank

        //1,20 blank

        //2,0 
        CAPS_LOCK = 63,

        //2,1 blank

        //2,2
        A = 65,

        //2,3
        S = 66,

        //2,4
        D = 67,

        //2,5
        F = 68,

        //2,6
        G = 69,

        //2,7
        H = 70,

        //2,8
        J = 71,

        //2,9
        K = 72,

        //2,10
        L = 73,

        //2,11
        SEMICOLON = 74,

        //2,12
        APOSTROPHE = 75,

        //2,13 blank

        //2,14
        ENTER = 77,

        //2,15
        PAGE_DOWN = 78,

        //2,16 blank

        //2,17 blank

        //2,18 blank

        //2,19 blank

        //2,20 blank

        //3,0
        TAB = 42,

        //3,1 blank

        //3,2
        Q = 44,

        //3,3
        W = 45,

        //3,4
        E = 46,

        //3,5
        R = 47,

        //3,6
        T = 48,

        //3,7
        Y = 49,

        //3,8
        U = 50,

        //3,9
        I = 51,

        //3,10
        O = 52,

        //3,11
        P = 53,

        //3,12
        OPEN_BRACKET = 54,

        //3,13
        CLOSE_BRACKET = 55,

        //3,14
        BACKSLASH = 56,

        //3,15
        PAGE_UP = 57,

        //3,16 blank

        //3,17 blank

        //3,18 blank

        //3,19 blank

        //3,20 blank

        //4,0
        TILDE = 21,

        //4,1
        ONE = 22,

        //4,2
        TWO = 23,

        //4,3
        THREE = 24,

        //4,4
        FOUR = 25,

        //4,5
        FIVE = 26,

        //4,6
        SIX = 27,

        //4,7
        SEVEN = 28,

        //4,8
        EIGHT = 29,

        //4,9
        NINE = 30,

        //4,10
        ZERO = 31,

        //4,11
        MINUS = 32,

        //4,12
        EQUALS = 33,

        //4,13 blank

        //4,14
        BACKSPACE = 35,

        //4,15
        HOME = 36,

        //4,16 blank

        //4,17 blank

        //4,18 blank

        //4,19 blank

        //4,20 blank

        //5,0
        ESCPAE = 0,

        //5,1
        F1 = 1,

        //5,2
        F2 = 2,

        //5,3
        F3 = 3,

        //5,4
        F4 = 4,

        //5,5
        F5 = 5,
        
        //5,6
        F6 = 6,

        //5,7
        F7 = 7,

        //5,8
        F8 = 8,

        //5,9
        F9 = 9,

        //5,10
        F10 = 10,

        //5,11
        F11 = 11,

        //5,12
        F12 = 12,

        //5,13
        INSERT = 13,

        //5,14
        PRINT_SCREEN = 14,

        //5,15
        DELETE = 15

        //5,16 blank

        //5,17 blank

        //5,18 blank

        //5,19 blank

        //5,20 blank
    }

    public enum ISOKey : byte//weird math is col + ((5 - row) * 21)
    {
        //0,0
        LEFT_CONTROL = 105,

        //0,1 blank

        //0,2
        FN_Key = 107,

        //0,3
        LEFT_WINDOWS = 108,

        //0,4
        LEFT_ALT = 109,

        //0,5 blank
        //0,6 blank

        //0,7
        SPACE = 112,

        //0,8 blank
        //0,9 blank

        //0,10
        RIGHT_ALT = 115,

        //0,11
        MENU = 116,

        //0,12
        RIGHT_CONTROL = 117,

        //0,13
        ARROW_LEFT = 118,

        //0,14
        DOWN_ARROW = 119,

        //0,15
        RIGHT_ARROW = 120,

        //0,16 
        NUMPAD_0 = 121,

        //0,17 
        NUMPAD_PERIOD = 122,
        //0,18 blank

        //0,19 blank

        //0,20 blank

        //1,0 blank
        LEFT_SHIFT = 84,

        //1,1 blank

        //1,2
        BACKSLASH_UK = 86,

        //1,3
        Z = 87,

        //1,4 
        X = 88,

        //1,5
        C = 89,

        //1,6
        V = 90,

        //1,7
        B = 91,

        //1,8
        N = 92,

        //1,9
        M = 93,

        //1,10
        COMMA = 94,

        //1,11
        PERIOD = 95,

        //1,12
        FORWARD_SLASH = 96,

        //1,13
        RIGHT_SHIFT = 97,

        //1,14
        UP_ARROW = 98,

        //1,15
        NUMPAD_ONE = 99,

        //1,16
        NUMPAD_TWO = 100,

        //1,17 
        NUMPAD_THREE = 101,

        //1,18
        NUMPAD_ENTER = 102,

        //1,19 blank

        //1,20 blank

        //2,0 
        CAPS_LOCK = 63,

        //2,1 blank

        //2,2
        A = 65,

        //2,3
        S = 66,

        //2,4
        D = 67,

        //2,5
        F = 68,

        //2,6
        G = 69,

        //2,7
        H = 70,

        //2,8
        J = 71,

        //2,9
        K = 72,

        //2,10
        L = 73,

        //2,11
        SEMICOLON = 74,

        //2,12
        APOSTROPHE = 75,

        //2,13 
        HASHTAG = 76, //UNDER ENTER, TODO

        //2,14 blank

        //2,15
        NUMPAD_FOUR = 78,

        //2,16 
        NUMPAD_FIVE = 79,

        //2,17
        NUMPAD_SIX = 80,

        //2,18 blank

        //2,19 blank

        //2,20 blank

        //3,0
        TAB = 42,

        //3,1 blank

        //3,2
        Q = 44,

        //3,3
        W = 45,

        //3,4
        E = 46,

        //3,5
        R = 47,

        //3,6
        T = 48,

        //3,7
        Y = 49,

        //3,8
        U = 50,

        //3,9
        I = 51,

        //3,10
        O = 52,

        //3,11
        P = 53,

        //3,12
        OPEN_BRACKET = 54,

        //3,13
        CLOSE_BRACKET = 55,

        //3,14
        ENTER = 56,

        //3,15
        NUMPAD_SEVEN = 57,

        //3,16 
        NUMPAD_EIGHT = 58,

        //3,17 
        NUMPAD_NINE = 59,

        //3,18 
        NUMPAD_PLUS = 60,

        //3,19 blank

        //3,20 blank

        //4,0
        TILDE = 21,

        //4,1
        ONE = 22,

        //4,2
        TWO = 23,

        //4,3
        THREE = 24,

        //4,4
        FOUR = 25,

        //4,5
        FIVE = 26,

        //4,6
        SIX = 27,

        //4,7
        SEVEN = 28,

        //4,8
        EIGHT = 29,

        //4,9
        NINE = 30,

        //4,10
        ZERO = 31,

        //4,11
        MINUS = 32,

        //4,12
        EQUALS = 33,

        //4,13 blank

        //4,14
        BACKSPACE = 35,

        //4,15
        NUMLOCK = 36,

        //4,16 
        NUMPAD_DIVIDE = 37,

        //4,17
        NUMPAD_MULTIPLY = 38,

        //4,18 
        NUMPAD_MINUS = 39,

        //4,19 blank

        //4,20 blank

        //5,0
        ESCAPE = 0,

        //5,1
        F1 = 1,

        //5,2
        F2 = 2,

        //5,3
        F3 = 3,

        //5,4
        F4 = 4,

        //5,5
        F5 = 5,

        //5,6
        F6 = 6,

        //5,7
        F7 = 7,

        //5,8
        F8 = 8,

        //5,9
        F9 = 9,

        //5,10
        F10 = 10,

        //5,11
        F11 = 11,

        //5,12
        F12 = 12,

        //5,13
        INSERT = 13,

        //5,14
        DELETE = 14,

        //5,15
        HOME = 15,

        //5,16 
        END = 16,

        //5,17 
        PAGE_UP = 17,

        //5,18 
        PAGE_DOWN = 18,

        //5,19 blank

        //5,20 blank
    }
}
