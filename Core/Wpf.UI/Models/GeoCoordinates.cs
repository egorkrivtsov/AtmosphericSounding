using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfUI.Models
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

        [DisplayName("Широта")]
        public double Latitude { get; set; }

        [DisplayName("Долгота")]
        public double Longitude { get; set; }

        [DisplayName("Высота")]
        [Range(0, 40000)]
        public double Height { get; set; }
    }
}