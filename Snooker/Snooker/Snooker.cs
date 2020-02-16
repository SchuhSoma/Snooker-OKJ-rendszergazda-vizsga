using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker
{
    class Snooker
    {
        //Helyezes;Nev;Orszag;Nyeremeny
        public int Helyezes;
        public string Nev;
        public string Orszag;
        public int Nyeremeny;

        public Snooker(string sor)
        {
            var dbok = sor.Split(';');
            this.Helyezes = int.Parse(dbok[0]);
            this.Nev = dbok[1];
            this.Orszag = dbok[2];
            this.Nyeremeny = int.Parse(dbok[3]);
        }

    }
}
