using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom_ukol
{
    class Kostka
    {
        private Random random;

        private int pocetSten;

        public Kostka()
        {
            pocetSten = 6;
            random = new Random();
        }

        public int VratPocetSten()
        {
            return pocetSten;
        }

        public Kostka(int pocetSten)
        {
            this.pocetSten = pocetSten;
            random = new Random();
        }

        public override string ToString()
        {
            return string.Format($"Kostka s {pocetSten} stěn");
        }

        public int Hod()
        {
            return random.Next(1, pocetSten + 1);
        }
    }
}
