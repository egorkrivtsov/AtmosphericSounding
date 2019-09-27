using System;

namespace Data.Models
{
    public class GroundStation
    {
        public int Index { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double Height { get; set; }

        public int? RadarAboveStation { get; set; }

        public double OnGroundPressure { get; set; }

        public double OnGroundWindDirection { get; set; }

        public double OnGroundWindVelocity { get; set; }

        public double OnGroundHumidityError { get; set; }

        public double OnGroundTemperatureError { get; set; }

        public DateTime Time { get; set; }

        public string NebulosityCode { get; set; }

        public int RadioZondType { get; set; }
    }
}