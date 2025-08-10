namespace MathsLibrary
{
    public static class Clamp
    {
        public static int IClamp(int value, int min, int max)
        {
            if (min > max)
                throw new ArgumentException("min cannot be greater than max");

            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static double IClamp(double value, double min, double max)
        {
            if (min > max)
                throw new ArgumentException("min cannot be greater than max");

            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static int EClamp(int value, int min, int max)
        {
            if (min >= max - 1)
                throw new ArgumentException("Exclusive range is too small for integers");

            if (value <= min) return min + 1;
            if (value >= max) return max - 1;
            return value;
        }

        public static double EClamp(double value, double min, double max)
        {
            if (min >= max)
                throw new ArgumentException("min must be less than max");

            if (value <= min) return NextUp(min);
            if (value >= max) return NextDown(max);
            return value;
        }

        // Helpers to find next representable doubles
        private static double NextUp(double x)
        {
            if (double.IsNaN(x) || x == double.PositiveInfinity) return x;
            if (x == 0.0) return double.Epsilon;
            long bits = BitConverter.DoubleToInt64Bits(x);
            return BitConverter.Int64BitsToDouble(x > 0 ? bits + 1 : bits - 1);
        }

        private static double NextDown(double x)
        {
            if (double.IsNaN(x) || x == double.NegativeInfinity) return x;
            if (x == 0.0) return -double.Epsilon;
            long bits = BitConverter.DoubleToInt64Bits(x);
            return BitConverter.Int64BitsToDouble(x > 0 ? bits - 1 : bits + 1);
        }
    }
}
