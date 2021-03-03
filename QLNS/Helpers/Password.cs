using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Helpers
{
    public class Password
    {
        public static string Random()
        {
            int length = 8;
            var result = "";
            Enumerable.Range(0, length).ToList().ForEach(x => result += RandomChar());
            return result;
        }

        private static char RandomChar()
        {
            var r = new Random();
            while (true)
            {
                var t = r.Next(255);
                var result = Convert.ToChar(t);
                if (CharacterValid(result)) return result;
            }
        }

        private static bool CharacterValid(char c)
        {
            if (c >= 'A' && c <= 'Z')
                return true;
            if (c >= 'a' && c <= 'z')
                return true;
            if (c >= '0' && c <= '9')
                return true;

            return false;
        }
    }
}
