﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dom_ukol_2
{
    internal class Bojovnik
    {
        ///Jmeno bojovnika
        protected string jmeno;
        ///Život v HP
        protected int zivot;
        ///Útok v HP
        protected int utok;
        ///Obrana v HP
        protected int obrana;
        /// Instance hrací kostky
        protected Kostka kostka;
        ///Zprava
        private string zprava;

        protected void NastavZpravu(string zprava)
        {
            this.zprava = zprava;
        }

        public string VratPosledniZpravu()
        {
            return zprava;
        }

        public Bojovnik(string jmeno, int zivot, int utok, int obrana, Kostka kosta)
        {
            this.jmeno = jmeno;
            this.zivot = zivot;
            this.utok = utok;
            this.obrana = obrana;
            this.kostka = kosta;
        }


        public int VratZivot()
        {
            return zivot;
        }

        public override string ToString()
        {
            return jmeno;
        }

        public bool Nazivu()
        {
            return (zivot > 0);
        }

        public void GrafickyZivot(Label l, ProgressBar p)
        {
            l.Text = this.VratZivot().ToString();
            p.Value = this.VratZivot();
        }

        public void BranSe(int uder)
        {
            int zraneni = uder - (obrana + kostka.Hod());
            if (zraneni > 0)
            {
                zivot -= zraneni;
                zprava = string.Format($"{jmeno} utrpěl poškození za {zraneni} HP");
                if (zivot <= 0)
                {
                    zivot = 0;
                    zprava += " a zemrel";
                }
            }
            else
            {
                zprava = string.Format($"{jmeno} odrazil utok");
                NastavZpravu(zprava);
            }
        }

        public virtual void Utoc(Bojovnik souper)
        {
            int uder = utok + kostka.Hod();
            NastavZpravu(string.Format($"{jmeno} útočí s úderem za {uder} HP."));
            souper.BranSe(uder);
        }
    }
}
