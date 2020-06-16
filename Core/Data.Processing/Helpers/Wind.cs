using System;

namespace Data.Processing.Helpers
{
    public static class Wind
    {
        public static double PowerByCoordinates(double x0, double x1, 
            double y0, double y1, 
            double t0, double t1)
        {
            double dx = x1 - x0;
            double dy = y1 - y0;
            double dt = t1 - t0;

            if (Math.Abs(dt) < 0.0001)
                return 0;

            return Math.Sqrt((Math.Pow(dx / dt, 2) + Math.Pow(dy / dt, 2)));
        }

        public static double PowerByVelocity(double vX, double vY) => Math.Sqrt(vX * vX + vY * vY);

        public static double Direction(double x0, double x1, double y0, double y1)
        {
            double dx = x1 - x0;
            double dy = y1 - y0;
            double res = Math.Abs(Math.Atan(dy / dx).ToDegree());

            if (res < 0)
                return Math.Abs(res) % 360.0;//mod
            return (360.0 - res) % 360.0;//mod;
        }
    }
}
