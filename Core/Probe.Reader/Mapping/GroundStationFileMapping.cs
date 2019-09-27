using System;
using System.Collections.Generic;
using System.Linq;
using Common.Exceptions;
using Common.Extensions;
using Data.Models;
using Data.Reader.Interfaces;

namespace Data.Reader.Mapping
{
    public class GroundStationFileMapping : ITxtLinesMapping<GroundStation> 
    {
        public GroundStation Map(IEnumerable<string[]> source, GroundStation destination)
        {
            if (destination == null)
                destination = new GroundStation();

            int? startYear = null, startMonth = null,
                startDay = null, startHour = null,
                startMinute = null;
            
            foreach (var keyValue in source)
            {
                if (keyValue.Length != 2)
                    throw new ParseException(keyValue);

                string key = keyValue[0].Trim().ToLower();
                string value = keyValue[1];

                if (key == "StationSynopticIndex".ToLower())
                {
                    destination.Index = value.ToInt();
                }
                else if (key == "StationLongitude".ToLower())
                {
                    destination.Longitude = value.ToDouble();
                }
                else if (key == "StationLattitude".ToLower())
                {
                    destination.Latitude = value.ToDouble();
                }
                else if (key == "StationHeightAboveSeaLevel".ToLower())
                {
                    destination.Height = value.ToDouble();
                }
                else if (key == "RadarAboveStationExeeding".ToLower())
                {
                    destination.RadarAboveStation = value.ToInt();
                }
                else if (key == "OnGroundPressure".ToLower())
                {
                    destination.OnGroundPressure = value.ToDouble();
                }
                else if (key == "OnGroundWindDirection".ToLower())
                {
                    destination.OnGroundWindDirection = value.ToDouble();
                }
                else if (key == "OnGroundWindVelocity".ToLower())
                {
                    destination.OnGroundWindVelocity = value.ToDouble();
                }
                else if (key == "OnGroundPressure".ToLower())
                {
                    destination.OnGroundPressure = value.ToDouble();
                }
                else if (key == "OnGroundHumidityError".ToLower())
                {
                    destination.OnGroundHumidityError = value.ToDouble();
                }
                else if (key == "OnGroundTemperatureError".ToLower())
                {
                    destination.OnGroundTemperatureError = value.ToDouble();
                }
                else if (key == "StartYear".ToLower())
                {
                    startYear = value.ToInt();
                }
                else if (key == "StartMonth".ToLower())
                {
                    startMonth = value.ToInt();
                }
                else if (key == "StartDay".ToLower())
                {
                    startDay = value.ToInt();
                }
                else if (key == "StartHour".ToLower())
                {
                    startHour = value.ToInt();
                }
                else if (key == "StartMinute".ToLower())
                {
                    startMinute = value.ToInt();
                }
                else if (key == "NebulosityCode".ToLower())
                {
                    destination.NebulosityCode = value;
                }
                else if (key == "RadioZondType".ToLower())
                {
                    destination.RadioZondType = value.ToInt();
                }
            }

            if (!startYear.HasValue
                || !startMonth.HasValue
                || !startDay.HasValue
                || !startHour.HasValue
                || !startMinute.HasValue
            )
                throw new ArgumentNullException();

            destination.Time = new DateTime(startYear.Value, startMonth.Value, startDay.Value, startHour.Value, startMinute.Value, 0);

            return destination;
        }

        public IEnumerable<string[]> Map(GroundStation source, IEnumerable<string[]> destination)
        {
            throw new NotImplementedException();
        }
    }
}
