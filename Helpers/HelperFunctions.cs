using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainspotting.Helpers
{
    public class HelperFunctions
    {
        private static Random _rand = new Random();

        public static string GenerateID()
        {
            const string allowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            char[] chars = new char[8];

            for (int i = 0; i < 8; i++)
            {
                chars[i] = allowedChars[_rand.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
