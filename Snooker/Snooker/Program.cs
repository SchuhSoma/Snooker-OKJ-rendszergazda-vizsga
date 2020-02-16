using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snooker
{
    class Program
    {
        static List<Snooker> SnookerList;
        static Dictionary<string, int> OrszagStatisztika;
        static List<string> OrszagList;
        static List<int> Darabszam;
        static void Main(string[] args)
        {
            Feladat2AdatokBeolvasasa();
            Console.WriteLine("\n-------------------------\n");
            Feladat3Ranglistahossza();
            Console.WriteLine("\n-------------------------\n");
            Feladat4Atlag();
            Console.WriteLine("\n-------------------------\n");
            Feladat5LegjobbKinai();
            Console.WriteLine("\n-------------------------\n");
            Feladat6Norveg();
            Console.WriteLine("\n-------------------------\n");
            Feladat7Statisztika();
            Console.ReadKey();
            
        }

        private static void Feladat7Statisztika()
        {
            Console.WriteLine("7.Felafat: határozza meg országonként hány induló volt:");
            OrszagStatisztika = new Dictionary<string, int>();
            OrszagList = new List<string>();
            Darabszam = new List<int>();
            foreach (var s in SnookerList)
            {
                if(!OrszagList.Contains(s.Orszag))
                {
                    OrszagList.Add(s.Orszag);
                }
            }
            foreach (var o in OrszagList)
            {
                //Console.WriteLine("{0}", o);
            }
            foreach (var o in OrszagList)
                {
                int dbO = 0;
                foreach (var sn in SnookerList)
                {
                    if(sn.Orszag==o)
                    {
                        dbO++;
                    }                   
                }
                //Console.WriteLine("\t{0,-30} : {1}", o, dbO);
                if (!OrszagStatisztika.ContainsKey(o))
                {
                    OrszagStatisztika.Add(o, dbO);
                }
                if(!Darabszam.Contains(dbO))
                {
                    Darabszam.Add(dbO);
                }
            }
            //Console.WriteLine("\n-------------------------\n");
            Darabszam.Sort();
            Darabszam.Reverse();
            foreach (var d in Darabszam)
            {
                foreach (var o in OrszagStatisztika)
                {
                    if (d == o.Value)
                    {
                        Console.WriteLine("\t{0,-30} : {1}", o.Key, o.Value);
                    }
                    
                }
            }
           
        }

        private static void Feladat6Norveg()
        {
            Console.WriteLine("6.Feladat: Határozza meg, hogy van-e Norvég versenyző a listán?");
            int dbN = 0;
            foreach (var s in SnookerList)
            {
                if(s.Orszag=="Norvégia")
                {
                    dbN++;
                }
            }
            if(dbN>0)
            {
                Console.WriteLine("\tVan Norvég származású versenyző a listán");
            }
            else
            {
                Console.WriteLine("\tNincs Norvég származású versenyző a listán");
            }
        }

        private static void Feladat5LegjobbKinai()
        {
            Console.WriteLine("\n5.Feladat: A legjobban kereső Kínai versenyző adatai");
            int MaxBevetel = int.MinValue;
            int MaxNyeremeny = 0;
            string MaxNEv = "Cica";
            string MAxOrszag = "Kutya";
            int MaxHelyezes = 0;
            foreach (var s in SnookerList)
            {
                if(MaxBevetel < s.Nyeremeny && s.Orszag == "Kína")
                {
                    MaxBevetel = s.Nyeremeny;
                    MaxNyeremeny = MaxBevetel * 380;
                    MaxNEv = s.Nev;
                    MAxOrszag = s.Orszag;
                    MaxHelyezes = s.Helyezes;
                }               
            }
            Console.WriteLine("\tHelyezes: {0}\n\tVersenyző neve: {1}\n\tSzármazási hely: {2}\n\tNyeremény összege: {3}", MaxHelyezes, MaxNEv, MAxOrszag, MaxNyeremeny);
        }

        private static void Feladat4Atlag()
        {
            Console.WriteLine("\n4.Feladat: Határozza me átlagban mennyit kerestek a versenyzők");
            double Osszes = 0;
            double Atlag=0;
            foreach (var s in SnookerList)
            {
                Osszes += s.Nyeremeny;
                Atlag = Osszes / SnookerList.Count;
            }
            Console.WriteLine("\tÁtlagosan ennyit kerestek a versenyzők: {0:0.00}", Atlag);
        }

        private static void Feladat3Ranglistahossza()
        {
            Console.WriteLine("\n3.Feladat: Határozza meg, hányan szerepelnek a világranglistán");
            Console.WriteLine("\tA ranglista ennyi személyt tartalmatz: {0}", SnookerList.Count);
        }

        private static void Feladat2AdatokBeolvasasa()
        {
            Console.WriteLine("\n2.Feladat: Adatok beolvasása");
            SnookerList = new List<Snooker>();
            int db = 0;
            var sr = new StreamReader(@"snooker.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                SnookerList.Add(new Snooker(sr.ReadLine()));
                db++;
            }
            if(db>0)
            {
                Console.WriteLine("\tSikeres Beolvasás: {0} adatot dolgozott fel", db);
            }
            else
            {
                Console.WriteLine("Elrontottad");
            }
        }
    }
}
