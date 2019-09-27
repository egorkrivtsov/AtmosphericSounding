using System.Collections.Generic;
using System.Linq;
using Data.Processing.Extensions;

namespace Data.Processing
{
    public class Tropopause
    {
        public Dictionary<double, double> Data { get; }

        public Tropopause(Dictionary<double, double> data)
        {
            Data = data;
        }

        public KeyValuePair<double, double> Calculate()
        {
            var derivatives = Data.Select(d => new double[] {d.Key, d.Value})
                .Filter(0, 1000)
                .Differentiate(0, 1).ToList();

            double heightFound = derivatives.First(d => d[1] > 0)[0];

            return Data
                .Where(x => x.Key > heightFound - 1000 && x.Key < heightFound + 1000)
                .Aggregate((min, x) => x.Value < min.Value ? x : min);
            
        }
    }
}
