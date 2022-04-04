using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apostassystem {
    public class JRandom {
        private const int m = 65537; // (2 ^ 16) + 1, a Fermat prime
        private const int a = 75; // a Primitive root modulo
        private const int x0 = 65536; // Number, greater than '0', less than 'm'

        private static int ox, cx;  // Original seed, Current seed
        private static readonly float md; // floating-point devider

        // Creates a constructor of random class
        static JRandom() {
            ox = x0;
            cx = x0;
            md = m - 1;
        }

        // Lehmer random number generator formula
        private static int RNG(int x) {
            return (x * a) % m;
        }

        // Random min-max number formula
        private static int RMM(int min, int max, int x) {
            return min + (x % (max - min));
        }

        // Random min-max number formula
        private static float RMM(float min, float max, float x) {
            return min + ((max - min) * x);
        }

        // Checks seed number is valid
        private static bool IV(int n) {
            if ((n <= 0) && (n >= m))
                throw new System.ArgumentException("Invalid seed number!");
            if (n % 1 != 0)
                throw new System.ArgumentException("Seed number should be an integer!");
            return true;
        }

        /// <summary>
        /// Get or Set a random seed number.
        /// </summary>
        public static int Seed {
            get => ox;
            set {
                IV(value);
                ox = value;
                cx = value;
            }
        }

        /// <summary>
        /// Returns a random integer number between [min, max).
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Integer number</returns>
        public static int Range(int min, int max) {
            if (min > max)
                throw new System.ArgumentOutOfRangeException("Invalid 'min'-'max' values");
            cx = RNG(cx);
            return RMM(min, max, cx);
        }

        /// <summary>
        /// Returns a random floating-point number between [min, max]
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Float number</returns>
        public static float Range(float min, float max) {
            if (min > max)
                throw new System.ArgumentOutOfRangeException("Invalid 'min'-'max' values");
            cx = RNG(cx);
            return RMM(min, max, RMM(0, m, cx) / md);
        }
    }
}
