using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    static class Randomizer
    {
        private readonly static Random random = new Random();
        private readonly static int maximumThrowRandomNumber = 100;
        private readonly static int maximumRoundsOfPainNumber = 3;

        public static Random GetRandom()
        {
            return random;
        }

        public static int Throw(int baseNumber)
        {
            return baseNumber + random.Next(1, maximumThrowRandomNumber + 1);
        }

        public static int RoundsOfPain()
        {
            return random.Next(1, maximumRoundsOfPainNumber + 1);
        }
    }
}
