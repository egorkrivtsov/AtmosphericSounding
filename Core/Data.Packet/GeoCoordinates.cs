using System;

namespace Data.Models
{
    public class GeoCoordinates
    {
        public GeoCoordinates()
        {
        }

        public GeoCoordinates(double latitude, double longitude, double height)
        {
            Latitude = latitude;
            Longitude = longitude;
            Height = height;
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Height { get; set; }
    }
}