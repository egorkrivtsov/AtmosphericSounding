using System.Collections.Generic;

namespace Data.Processing.Extensions
{
    public static class Derivative
    {
        public static IEnumerable<double[]> Differentiate(this IEnumerable<double[]> source, 
            int parameterIndex,
            int funcIndex)
        {
            List<double[]> derivatives = new List<double[]>();
            int index = 0;
            double[] prevLine = new double[0];

            foreach (var line in source)
            {
                if (index == 0)
                    prevLine = line;
                else 
                {
                    var value = (line[funcIndex] - prevLine[funcIndex]) / (line[parameterIndex] - prevLine[parameterIndex]);
                    var derivativesLine = new double[line.Length];
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (i == parameterIndex)
                            derivativesLine[i] = prevLine[parameterIndex];
                        else if (i== funcIndex)
                            derivativesLine[i] = value;
                        else
                            derivativesLine[i] = line[i];
                    }

                    derivatives.Add(derivativesLine);
                    prevLine = line;
                }
                index++;
            }
            return derivatives;
        }

        public static IEnumerable<double[]> Filter(this IEnumerable<double[]> source,
            int filterIndex,
            int step)
        {
            List<double[]> filtered = new List<double[]>();
            double? filteredValue =default(double?);
            foreach (var line in source)
            {
                if (!filteredValue.HasValue)
                {
                    filteredValue = step;
                    filtered.Add(line);
                }
                else if (line[filterIndex]> filteredValue)
                {
                    filtered.Add(line);
                    filteredValue += step;
                }
            }

            return filtered;
        }
    }
}
