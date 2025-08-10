using MathsLibrary;

namespace Testing
{
    internal class Program
    {
        static int Main()
        {
            Console.WriteLine("Beginning test on MathsLibrary");
            Console.WriteLine("Will return 0 if all tests pass, or 1 if any test fails.");
            Console.WriteLine("Beginning tests...");
            // Test IClamp
            int result = Clamp.IClamp(5, 1, 10); // should return 5
            if (result != 5)
            {
                Console.WriteLine($"IClamp failed: expected 5, got {result}");
                return 1;
            }
            result = Clamp.IClamp(0, 1, 10); // should return 1
            if (result != 1)
            {
                Console.WriteLine($"IClamp failed: expected 1, got {result}");
                return 1;
            }
            result = Clamp.IClamp(15, 1, 10); // should return 10
            if (result != 10)
            {
                Console.WriteLine($"IClamp failed: expected 10, got {result}");
                return 1;
            }
            try
            {
                result = Clamp.IClamp(5, 10, 1); // Should throw exception
                Console.WriteLine("IClamp did not throw exception for invalid range");
                return 1;
            }
            catch (ArgumentException)
            {
                // Expected exception
            }
            // Test EClamp
            result = Clamp.EClamp(5, 1, 10); // should return 5
            if (result != 5)
            {
                Console.WriteLine($"EClamp failed: expected 5, got {result}");
                return 1;
            }
            result = Clamp.EClamp(1, 1, 10); // should return 2
            if (result != 2)
            {
                Console.WriteLine($"EClamp failed: expected 2, got {result}");
                return 1;
            }
            result = Clamp.EClamp(10, 1, 10); // should return 9
            if (result != 9)
            {
                Console.WriteLine($"EClamp failed: expected 9, got {result}");
                return 1;
            }
            try
            {
                result = Clamp.EClamp(5, 10, 1); // Should throw exception
                Console.WriteLine("EClamp did not throw exception for invalid range");
                return 1;
            }
            catch (ArgumentException)
            {
                // Expected exception
            }
            // Test IClamp with doubles
            double dResult = Clamp.IClamp(5.5, 1.0, 10.0); // should return 5.5
            if (dResult != 5.5)
            {
                Console.WriteLine($"IClamp (double) failed: expected 5.5, got {dResult}");
                return 1;
            }
            dResult = Clamp.IClamp(0.5, 1.0, 10.0); // should return 1.0
            if (dResult != 1.0)
            {
                Console.WriteLine($"IClamp (double) failed: expected 1.0, got {dResult}");
                return 1;
            }
            dResult = Clamp.IClamp(15.5, 1.0, 10.0); // should return 10.0
            if (dResult != 10.0)
            {
                Console.WriteLine($"IClamp (double) failed: expected 10.0, got {dResult}");
                return 1;
            }
            try
            {
                dResult = Clamp.IClamp(5.5, 10.0, 1.0); // Should throw exception
                Console.WriteLine("IClamp (double) did not throw exception for invalid range");
                return 1;
            }
            catch (ArgumentException)
            {
                // Expected exception
            }
            // Test EClamp with doubles
            dResult = Clamp.EClamp(5.5, 1.0, 10.0); // should return 5.5
            if (dResult != 5.5)
            {
                Console.WriteLine($"EClamp (double) failed: expected 5.5, got {dResult}");
                return 1;
            }
            dResult = Clamp.EClamp(1.0, 1.0, 10.0); // should return next representable double above 1.0
            if (Math.Abs(dResult - NextUp(1.0)) > double.Epsilon)
            {
                Console.WriteLine($"EClamp (double) failed: expected next representable double above 1.0, got {dResult}");
                return 1;
            }
            dResult = Clamp.EClamp(10.0, 1.0, 10.0); // should return next representable double below 10.0
            if (Math.Abs(dResult - NextDown(10.0)) > double.Epsilon)
            {
                Console.WriteLine($"EClamp (double) failed: expected next representable double below 10.0, got {dResult}");
                return 1;
            }
            try
            {
                dResult = Clamp.EClamp(5.5, 10.0, 1.0); // Should throw exception
                Console.WriteLine("EClamp (double) did not throw exception for invalid range");
                return 1;
            }
            catch (ArgumentException)
            {
                // Expected exception
            }
            // If we reach here, all tests passed for Clamping
            Console.WriteLine("All clamping tests passed successfully!");
            // Test WordsToNumber
            Console.WriteLine("Testing WordsToNumber...");
            String testString = "one hundred and twenty three";
            long number = NumFromText.WordsToNumber(testString);
            if (number != 123)
            {
                Console.WriteLine($"WordsToNumber failed: expected 123, got {number}");
                return 1;
            }
            testString = "four thousand five hundred and sixty seven";
            number = NumFromText.WordsToNumber(testString);
            if (number != 4567)
            {
                Console.WriteLine($"WordsToNumber failed: expected 4567, got {number}");
                return 1;
            }
            testString = "ninety nine thousand nine hundred and ninety nine";
            number = NumFromText.WordsToNumber(testString);
            if (number != 99999)
            {
                Console.WriteLine($"WordsToNumber failed: expected 99999, got {number}");
                return 1;
            }
            // test extremely wrong string
            testString = "Bees cannot fly";
            try
            {
                number = NumFromText.WordsToNumber(testString);
                Console.WriteLine("WordsToNumber did not throw exception for invalid input");
                return 1;
            }
            catch (ArgumentException)
            {
                // Expected exception
            }
            // test empty string. Should expect 0
            testString = "";
            number = NumFromText.WordsToNumber(testString);
            if (number != 0)
            {
                Console.WriteLine($"WordsToNumber failed: expected 0, got {number}");
                return 1;
            }
            // test string with only "and"
            testString = "and";
            number = NumFromText.WordsToNumber(testString);
            if (number != 0)
            {
                Console.WriteLine($"WordsToNumber failed: expected 0, got {number}");
                return 1;
            }
            // test string with only "zero"
            testString = "zero";
            number = NumFromText.WordsToNumber(testString);
            if (number != 0)
            {
                Console.WriteLine($"WordsToNumber failed: expected 0, got {number}");
                return 1;
            }
            // test string with "one million"
            testString = "one million";
            number = NumFromText.WordsToNumber(testString);
            if (number != 1000000)
            {
                Console.WriteLine($"WordsToNumber failed: expected 1000000, got {number}");
                return 1;
            }
            // test string with "one billion"
            testString = "one billion";
            number = NumFromText.WordsToNumber(testString);
            if (number != 1000000000)
            {
                Console.WriteLine($"WordsToNumber failed: expected 1000000000, got {number}");
                return 1;
            }
            // test string with "one trillion"
            testString = "one trillion";
            number = NumFromText.WordsToNumber(testString);
            if (number != 1000000000000)
            {
                Console.WriteLine($"WordsToNumber failed: expected 1000000000000, got {number}");
                return 1;
            }
            // test string with "one quadrillion"
            testString = "one quadrillion";
            number = NumFromText.WordsToNumber(testString);
            if (number != 1000000000000000)
            {
                Console.WriteLine($"WordsToNumber failed: expected 1000000000000000, got {number}");
                return 1;
            }
            // test string with "one quintillion"
            testString = "one quintillion";
            number = NumFromText.WordsToNumber(testString);
            if (number != 1000000000000000000)
            {
                Console.WriteLine($"WordsToNumber failed: expected 1000000000000000000, got {number}");
                return 1;
            }
            // all tests passed
            Console.WriteLine("All WordsToNumber tests passed successfully!");
            // Test TextToNumber
            Console.WriteLine("Testing TextToNumber...");
            long textNumber = NumFromText.TextToNumber("12345");
            if (textNumber != 12345)
            {
                Console.WriteLine($"TextToNumber failed: expected 12345, got {textNumber}");
                return 1;
            }
            textNumber = NumFromText.TextToNumber("0");
            if (textNumber != 0)
            {
                Console.WriteLine($"TextToNumber failed: expected 0, got {textNumber}");
                return 1;
            }
            textNumber = NumFromText.TextToNumber("1000000");
            if (textNumber != 1000000)
            {
                Console.WriteLine($"TextToNumber failed: expected 1000000, got {textNumber}");
                return 1;
            }
            textNumber = NumFromText.TextToNumber("999999999999999999");
            if (textNumber != 999999999999999999)
            {
                Console.WriteLine($"TextToNumber failed: expected 999999999999999999, got {textNumber}");
                return 1;
            }
            // test invalid
            try
            {
                textNumber = NumFromText.TextToNumber("one hundred and twenty three");
                Console.WriteLine("TextToNumber did not throw exception for invalid input");
                return 1;
            }
            catch (ArgumentException)
            {
                // Expected exception
            }
            // test empty string. may throw
            try
            {
                textNumber = NumFromText.TextToNumber("");
                Console.WriteLine("TextToNumber did not throw exception for empty input");
                return 1;
            }
            catch (ArgumentException)
            {
                // Expected exception
            }
            // all tests passed
            Console.WriteLine("All TextToNumber tests passed successfully!");
            Console.WriteLine("All tests passed successfully!");
            return 0;
        }
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
