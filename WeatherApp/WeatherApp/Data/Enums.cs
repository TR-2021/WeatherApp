using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Data
{
    public static class Enums
    {
        public enum TintModeEnum : uint
        {
            MULTIPLY,
            SRC_IN,
            SRC_ATOP,
            SRC,
            SCREEN,
            OVERLAY,
            XOR,
            LIGHTEN,
            SRC_OUT,
            DST_OVER,
            DST_IN,
            DST_ATOP,
            DST,
            DARKEN,
            CLEAR,
            ADD,
            DST_OUT,
            SRC_OVER
        }
    }
}
