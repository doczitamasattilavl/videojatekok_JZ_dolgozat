using ConsoleApp1;


class Program
{
    static void Main(string[] args)
    {
        string utvonal = "videogames.csv";

        if (!File.Exists(utvonal))
        {
            utvonal = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "videogames.csv");
        }


        List<Videojatek> jatekok = new List<Videojatek>();
        string[] sorok = File.ReadAllLines(utvonal);


        for (int i = 1; i < sorok.Length; i++)
        {
            string sor = sorok[i];
            if (sor.Trim() == "") continue;

            string[] mezok = sor.Split(',');

            string cim = mezok[0];
            string mufaj = mezok[1];
            DateTime datum = DateTime.Parse(mezok[2]);
            int jatekosok = int.Parse(mezok[3]);
            double ertekeles = double.Parse(mezok[4], System.Globalization.CultureInfo.InvariantCulture);


            jatekok.Add(new Videojatek(cim, mufaj, datum, jatekosok, ertekeles));

        }

        Console.WriteLine("Beolvasott jatekok szama: " + jatekok.Count);
        Console.WriteLine();


        //1
        int db = 0;
        for (int i = 0; i < jatekok.Count; i++)
        {

            if (jatekok[i].Ertekeles > 4.5)
                db++;
        }

        Console.WriteLine("1. 4.5-nel jobbra ertekelt jatekok: " + db + " db");


        //2

        int maxHely = 0;
        for (int i = 1; i < jatekok.Count; i++)
        {

            if (jatekok[i].AktivJatekosok > jatekok[maxHely].AktivJatekosok)
                maxHely = i;
        }

        Console.WriteLine("2. Legtobb aktiv jatekosa: " + jatekok[maxHely].Cim + " (" + jatekok[maxHely].AktivJatekosok + " fo)");




        // 3
        DateTime hatar = new DateTime(2020, 1, 1);
        bool van = false;
        int j = 0;

        while (j < jatekok.Count && !van)
        {
            if (jatekok[j].KiadasDatum < hatar)
                van = true;
            j = j + 1;
        }

        if (van)
            Console.WriteLine("3. Van 2020.01.01 elott kiadott jatek.");

        else
            Console.WriteLine("3. Nincs ilyen jatek.");


        //4
        double osszeg = 0;

        for (int i = 0; i < jatekok.Count; i++)
        {
            osszeg += jatekok[i].Ertekeles;
        }

        double atlag = osszeg / jatekok.Count;

        Console.WriteLine("4. Atlag ertekeles: " + Math.Round(atlag, 3));

        //5

        string keresett = "Cyber City 2077";
        int talalt = -1;

        for (int i = 0; i < jatekok.Count; i++)
        {
            if (jatekok[i].Cim == keresett)
            {
                talalt = i;
                break;

            }

        }
        if (talalt != -1)
            Console.WriteLine("5. Megvan: " + jatekok[talalt].ToString());

        else
            Console.WriteLine("5. Nincs ilyen jatek a listaban.");


        //6

        List<Videojatek> rpgk = new List<Videojatek>();

        for (int i = 0; i < jatekok.Count; i++)
        {

            if (jatekok[i].Mufaj == "RPG")
                rpgk.Add(jatekok[i]);

        }

        for (int i = 0; i < rpgk.Count - 1; i++)
        {
            for (int k = 0; k < rpgk.Count - 1 - i; k++)

            {
                if (rpgk[k].KiadasDatum < rpgk[k + 1].KiadasDatum)
                {
                    Videojatek temp = rpgk[k];
                    rpgk[k] = rpgk[k + 1];
                    rpgk[k + 1] = temp;
                }
            }
        }

        Console.WriteLine("6. RPG jatekok (datum szerint csokkenoen):");

        for (int i = 0; i < rpgk.Count; i++)
        {
            Console.WriteLine("   " + rpgk[i].KiadasDatum.ToString("yyyy-MM-dd") + " - " + rpgk[i].Cim);
        }


        //7

            Console.ReadKey();
        }
    }

