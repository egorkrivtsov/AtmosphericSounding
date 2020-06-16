using System;
using System.Collections.Generic;
using Common.Exceptions;
using Common.Extensions;
using Common.Extensions.Converters;
using Data.Reader.Interfaces;

namespace Data.Reader.Mapping
{
   
    public class GroundStation : ITxtLinesMapping<Data.Models.GroundStation>
    {
        public Data.Models.GroundStation Map(IEnumerable<string[]> source, Data.Models.GroundStation destination)
        {
            destination ??= new Data.Models.GroundStation();
            
            (int?year, int? month, int? day, int? hour, int? minute) launchDateTime
                = (null, null, null, null, null);
            
            bool IsEquals(string s1, string s2) => string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
            
            foreach (string[] keyValuePair in source)
            {
                if (keyValuePair.Length != 2)
                    throw new ParseException(keyValuePair);

                (string key, string val) pair = (keyValuePair[0].Trim().ToLower(), keyValuePair[1]);
                    
                switch (pair.key)
                {
                    case var key when IsEquals(key,"StationSynopticIndex"): 
                        destination.Index = pair.val.ToInt();
                        break;
                    case var key when IsEquals(key,"StationLongitude"):
                        destination.Longitude = pair.val.ToDouble();
                        break;
                    case var key when IsEquals(key,"StationLattitude"):
                        destination.Latitude = pair.val.ToDouble();
                        break;
                    case var key when IsEquals(key,"StationHeightAboveSeaLevel"):
                        destination.Height = pair.val.ToDouble();
                        break;
                    case var key when IsEquals(key,"RadarAboveStationExeeding"):
                        destination.RadarAboveStation = pair.val.ToInt();
                        break;
                    case var key when IsEquals(key,"OnGroundPressure"):
                        destination.OnGroundPressure = pair.val.ToDouble();
                        break;
                }

                if (pair.key == "StationSynopticIndex".ToLower())
                    destination.Index = pair.val.ToInt();
                else if (pair.key == "StationLongitude".ToLower())
                    destination.Longitude = pair.val.ToDouble();
                else if (pair.key == "StationLattitude".ToLower())
                    destination.Latitude = pair.val.ToDouble();
                else if (pair.key == "StationHeightAboveSeaLevel".ToLower())
                    destination.Height = pair.val.ToDouble();
                else if (pair.key == "RadarAboveStationExeeding".ToLower())
                    destination.RadarAboveStation = pair.val.ToInt();
                else if (pair.key == "OnGroundPressure".ToLower())
                    destination.OnGroundPressure = pair.val.ToDouble();
                else if (pair.key == "OnGroundWindDirection".ToLower())
                    destination.OnGroundWindDirection = pair.val.ToDouble();
                else if (pair.key == "OnGroundWindVelocity".ToLower())
                    destination.OnGroundWindVelocity = pair.val.ToDouble();
                else if (pair.key == "OnGroundPressure".ToLower())
                    destination.OnGroundPressure = pair.val.ToDouble();
                else if (pair.key == "OnGroundHumidityError".ToLower())
                    destination.OnGroundHumidityError = pair.val.ToDouble();
                else if (pair.key == "OnGroundTemperatureError".ToLower())
                    destination.OnGroundTemperatureError = pair.val.ToDouble();
                else if (pair.key == "StartYear".ToLower())
                    launchDateTime.year = pair.val.ToInt();
                else if (pair.key == "StartMonth".ToLower())
                    launchDateTime.month = pair.val.ToInt();
                else if (pair.key == "StartDay".ToLower())
                    launchDateTime.day = pair.val.ToInt();
                else if (pair.key == "StartHour".ToLower())
                    launchDateTime.hour = pair.val.ToInt();
                else if (pair.key == "StartMinute".ToLower())
                    launchDateTime.minute = pair.val.ToInt();
                else if (pair.key == "NebulosityCode".ToLower())
                    destination.NebulosityCode = pair.val;
                else if (pair.key == "RadioZondType".ToLower()) 
                    destination.RadioZondType = pair.val.ToInt();
            }

            destination.Time = GetDateTime(launchDateTime);

            return destination;
        }

        public IEnumerable<string[]> Map(Data.Models.GroundStation source, IEnumerable<string[]> destination)
        {
            throw new NotSupportedException();
        }
        
        private bool IsDateTimeValid((int?year, int? month, int? day, int? hour, int? minute) dt)
            => dt.year.HasValue && dt.month.HasValue && dt.day.HasValue 
               && dt.hour.HasValue && dt.minute.HasValue;

        private DateTime GetDateTime((int?year, int? month, int? day, int? hour, int? minute) dt) =>
            IsDateTimeValid(dt)
                ? new DateTime(dt.year.Value, dt.month.Value, dt.day.Value,
                    dt.hour.Value, dt.minute.Value, 0)
                : throw new ArgumentNullException();
    }
}
