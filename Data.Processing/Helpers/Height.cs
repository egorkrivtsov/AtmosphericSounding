using System;
using Data.Processing.Common;

namespace Data.Processing.Helpers
{
    public static class Height
    {
        public static double GeoPotential(double height, double latitude)
        {
            //g*R*H
            double tmpVar1 = AccelerationOfGravity(latitude) * Constants.RadiusEarth * height;
            //gc(R+H)
            double tmpVar2 = Constants.GravityAcceleration * (Constants.RadiusEarth + height);
            return tmpVar1 / tmpVar2;
        }

        public static double AccelerationOfGravity(double latitude)
        {
            double variable = Math.Cos(2 * latitude);
            return Constants.GravityAcceleration * (1 - Constants.A * variable + Constants.B * Math.Pow(variable, 3));
        }

        public static double CalculateBySphericalCoordinates(double radialDistance, double zenithDirection, double initialHeight)
        {
            double r0 = initialHeight + Constants.Sigma * Constants.RadiusEarth;
            double tmp1 = Math.Pow(r0, 2) + Math.Pow(radialDistance, 2);
            double tmp2 = 2 * r0 * radialDistance * Math.Cos(zenithDirection + Math.PI / 2);
            return Math.Sqrt(tmp1 - tmp2) - Constants.Sigma * Constants.RadiusEarth;
        }
    }
}
