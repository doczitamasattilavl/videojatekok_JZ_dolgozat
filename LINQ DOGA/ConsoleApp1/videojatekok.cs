using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Videojatek
    {
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public DateTime KiadasDatum { get; set; }
        public int AktivJatekosok { get; set; }
        public double Ertekeles { get; set; }

        public Videojatek(string cim, string mufaj, DateTime datum, int jatekosok, double ertekeles)
        {

            this.Cim = cim;
            this.Mufaj = mufaj;
            this.KiadasDatum = datum;
            this.AktivJatekosok = jatekosok;
            this.Ertekeles = ertekeles;
        }


        public override string ToString()
        {
            return Cim + " (" + Mufaj + ", " + KiadasDatum.ToString("yyyy-MM-dd") + ") - " + Ertekeles;

        }
    }

}