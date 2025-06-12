using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mayinTarlasiSon
{
    public class Hucre
    {
        private bool mayinVar;
        private bool acildi;
        private bool isaretli;
        private int cevreMayinSayisi;

        public bool Acildi => acildi;
        public bool Isaretli => isaretli;
        public bool MayinVar => mayinVar;
        public int CevreMayinSayisi => cevreMayinSayisi;

        public void Ayarla(bool mayin, int cevreMayin)
        {
            mayinVar = mayin;
            cevreMayinSayisi = cevreMayin;
        }

        public void Ac()
        {
            if (!acildi && !isaretli)
                acildi = true;
        }

        public void Isaretle()
        {
            if (!acildi)
                isaretli = !isaretli;
        }
    }
}
