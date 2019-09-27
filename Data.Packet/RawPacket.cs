using System;

namespace Data.Models
{
    public class RawPacket 
    {
        public RawPacket()
        {
            this.Coordinates = new GeoCoordinates();
        }

        public DateTime DateTimeUtc { get; set; }

        public int Id { get; set; }

        public GeoCoordinates Coordinates { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

    }
}
