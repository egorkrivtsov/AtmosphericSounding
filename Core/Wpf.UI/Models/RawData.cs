using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WpfUI.ViewModels;

namespace WpfUI.Models
{
    public class RawData
    {
        public RawData()
        {
            this.Coordinates = new GeoCoordinates();
        }

        [DisplayName("№")]
        public int Id { get; set; }


        [DisplayName("Время")]
        public DateTime DateTimeUtc { get; set; }


        public GeoCoordinates Coordinates { get; set; }

        [DisplayName("Температура")]
        [Range(-100,100)]
        public double Temperature { get; set; }


        [DisplayName("Влажность")]
        [Range(0, 100)]
        public double Humidity { get; set; }

    }
}
