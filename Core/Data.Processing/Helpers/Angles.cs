﻿using System;

namespace Data.Processing.Helpers
{
    public static class Angles
    {
        public static double ToDegree(this double radian)
        {
            return radian * 180.0 / Math.PI;
        }
        public static double ToRadians(this double degree)
        {
            return degree * Math.PI / 180.0;
        }
    }
}