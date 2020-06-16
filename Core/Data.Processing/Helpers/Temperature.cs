using System;
using System.Collections.Generic;
using System.Text;
using Data.Processing.Common;

namespace Data.Processing.Helpers
{
    public static class Temperature
    {
        public static double ToKelvin(this double celsiusDegree) => celsiusDegree + Constants.KelvinCoefficient;

        public static double ToCelsiusDegree(this double kelvin) => kelvin - Constants.KelvinCoefficient;
    }
}
