using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dom_ukol
{
    internal class Mag: Bojovnik
    {
        private int mana;
        private int maxMana;
        private int magickyUtok;
        public Mag(string jmeno, int zivot, int utok, int obrana, Kostka kostka, int mana, int magickyUtok) : base(jmeno, zivot, utok, obrana, kostka)
        {
            this.mana = mana;
            this.maxMana = mana;
            this.magickyUtok = magickyUtok;
        }

        public override void Utoc(Bojovnik souper)
        {
            int uder = 0;

            if (mana > maxMana)
            {
                mana += 10;
                if (mana < maxMana)
                {
                    mana = maxMana;
                    base.Utoc(souper);
                }
                else
                {
                    uder = magickyUtok + kostka.Hod();
                    NastavZpravu(string.Format($"{jmeno} použil magii za {uder} HP."));
                    mana = 0;
                }
                souper.BranSe(uder);
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
