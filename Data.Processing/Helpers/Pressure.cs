using System;
using Data.Processing.Common;

namespace Data.Processing.Helpers
{
    public static class Pressure
    {
        public static double CalculatePartial(double ui0, double ui1, double ti0, double ti1)
        {
            double averageHumidity = (ui0 + ui1)/2;
            //to kelvin
            double averageTemperature = ((ti0 + ti1) / 2).ToKelvin();
            return averageHumidity * Constants.E0 * Math.Exp(Constants.PartialPressure * averageTemperature / averageTemperature);
        }

        public static double Calculate(double pi0, 
            double ti0, double ti1, 
            double ui0, double ui1, 
            double hi0, double hi1)
        {
            double partialVapourPressure = CalculatePartial(ui0, ui1, ti0, ti1);
            double averageTemperature = ((ti0 + ti1) / 2).ToKelvin();
            double dH = hi1 - hi0;
            double gammaEi = Constants.Gamma * partialVapourPressure;
            return gammaEi + (pi0 - gammaEi) * Math.Exp(Constants.Alpha * dH / averageTemperature);
        }
    }
}
