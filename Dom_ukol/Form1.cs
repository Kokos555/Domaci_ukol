using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dom_ukol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kostka kostka = new Kostka(10);
            string jmenoBojovnika1 = textBox1.Text;
            Bojovnik bojovnik1 = new Bojovnik(jmenoBojovnika1, 10, 20, 10, kostka);

            bojovnik1.GrafickyZivot(label2, progressBar1);

            string jmenoBojovnika2 = textBox2.Text;
            Bojovnik bojovnik2 = new Bojovnik(jmenoBojovnika2, 6, 15, 12, kostka);
            bojovnik2.GrafickyZivot(label4, progressBar2);
            

            Bojovnik b1 = bojovnik1;
            Bojovnik b2 = bojovnik2;

            bool zacinaBojovnik2 = (kostka.Hod() <= kostka.VratPocetSten() / 2);
            
            if (zacinaBojovnik2)
            {
                b1 = bojovnik2;
                b2 = bojovnik1;
            }

            MessageBox.Show(string.Format($"Začínat bude bojovník {b1.ToString()}\n Zápas muže začít"));
            while (b1.Nazivu() && b2.Nazivu())
            {
                b1.Utoc(b2);

                MessageBox.Show(b1.VratPosledniZpravu());
                MessageBox.Show(b2.VratPosledniZpravu());

                if (b2.Nazivu())
                {
                    b2.Utoc(b1);

                    MessageBox.Show(b2.VratPosledniZpravu());
                    MessageBox.Show(b1.VratPosledniZpravu());

                    bojovnik1.GrafickyZivot(label2, progressBar1);
                    bojovnik2.GrafickyZivot(label4, progressBar2);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random obr = new Random();
            int cisloObr = obr.Next(0, 5);
            pictureBox1.Image = imageList1.Images[cisloObr];
            cisloObr = obr.Next(0, 5);
            pictureBox2.Image = imageList1.Images[cisloObr];

        }
    }
}
