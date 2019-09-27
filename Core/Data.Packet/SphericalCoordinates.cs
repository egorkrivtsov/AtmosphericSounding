using System;

namespace Data.Models
{
    public class SphericalCoordinates
    {
        public SphericalCoordinates()
        {
        }

        public SphericalCoordinates(double radialDistance, double azimuthAngle, double zenithDirection)
        {
            RadialDistance = radialDistance;
            ZenithDirection = zenithDirection;
            AzimuthAngle = azimuthAngle;
        }

        public double RadialDistance { get; set; }

        public double ZenithDirection { get; set; }

        public double AzimuthAngle { get; set; }

        public GeoCoordinates ConvertTo(GroundStation groundStation)
        {
            return new GeoCoordinates
            {
                Longitude = groundStation.Longitude + RadialDistance * Math.Cos(ZenithDirection) * Math.Cos(AzimuthAngle) / Constants.RadiusEarth,
                Latitude = groundStation.Latitude + RadialDistance * Math.Cos(ZenithDirection) * Math.Sin(AzimuthAngle) / Constants.RadiusEarth,
                Height = CalculateHeight(groundStation)
            };
        }

        private double CalculateHeight(GroundStation gs)
        {
            double r0 = gs.Height + Constants.Sigma * Constants.RadiusEarth;
            double tmp1 = Math.Pow(r0,2) + Math.Pow(RadialDistance, 2);
            double tmp2 = 2 * r0 * RadialDistance * Math.Cos(ZenithDirection + Math.PI / 2);
            return Math.Sqrt(tmp1-tmp2)- Constants.Sigma * Constants.RadiusEarth;
        }
    }
}