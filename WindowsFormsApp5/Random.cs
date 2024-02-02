using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    public static class Util
    {
        private static Random rnd = new Random();
        public static int GetRandom(int n, int m)
        {
            return rnd.Next(n, m);
        }
    }
}
