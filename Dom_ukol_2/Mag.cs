using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dom_ukol_2
{
    internal class Mag: Bojovnik
    {
        private int mana;
        private int maxMana;
        private int magickyUtok;

        public Mag(string jmeno, int zivot, int utok, int obrana, Kostka kostka, int mana, int magickyUtok): base(jmeno, zivot, utok, obrana, kostka)
        {
            this.mana = mana;
            this.maxMana = mana;
            this.magickyUtok = magickyUtok;
        }

        public override void Utoc(Bojovnik souper)
        {
            // Mana není naplněna
            if (mana < maxMana)
            {
                mana += 10;
                if (mana > maxMana) mana = maxMana;
                base.Utoc(souper);
            }
            else // Magický útok
            {
                int uder = magickyUtok + kostka.Hod();
                NastavZpravu(String.Format("{0} použil magii za {1} hp", jmeno, uder));
                souper.BranSe(uder);
                mana = 0;
            }
        }

        public int VratMana()
        {
            return mana;
        }

        public void GrafickyMana(Label l)
        {
            l.Text = this.VratMana().ToString();
        }
    }
}
