using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mayinTarlasiSon
{
    public class Tahta
    {
        public Hucre[,] Hucreler { get; private set; }
        public int Satir { get; }
        public int Sutun { get; }

        public Tahta(int satir, int sutun, int mayinSayisi)
        {
            Satir = satir;
            Sutun = sutun;
            Hucreler = new Hucre[satir, sutun];
            for (int i = 0; i < satir; i++)
                for (int j = 0; j < sutun; j++)
                    Hucreler[i, j] = new Hucre();

            MayinlariYerlestir(mayinSayisi);
        }

        private void MayinlariYerlestir(int mayinSayisi)
        {
            Random rnd = new Random();
            int yerlestirilen = 0;

            while (yerlestirilen < mayinSayisi)
            {
                int x = rnd.Next(Satir);
                int y = rnd.Next(Sutun);
                if (!Hucreler[x, y].MayinVar)
                {
                    Hucreler[x, y].Ayarla(true, 0);
                    yerlestirilen++;
                }
            }

            
            for (int i = 0; i < Satir; i++)
            {
                for (int j = 0; j < Sutun; j ++)
                {
                    if (!Hucreler[i, j].MayinVar)
                    {
                        int count = KomsuMayinSayisi(i, j);
                        Hucreler[i, j].Ayarla(false, count);
                    }
                }
            }
        }

        private int KomsuMayinSayisi(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i ++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < Satir && j < Sutun && Hucreler[i, j].MayinVar)
                        count++;
                }
            }
            return count;
        }
        public void BosluklariAc(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Satir || y >= Sutun)
                return;
            
            var hucre = Hucreler[x, y];
            if (hucre.Acildi || hucre.Isaretli || hucre.MayinVar)
                return;

            hucre.Ac();

            if (hucre.CevreMayinSayisi == 0)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx != 0 || dy != 0)
                            BosluklariAc(x + dx, y + dy);
                    }
                }
            }
        }

        public bool OyunKazandiMi()
        {
            for (int i = 0; i < Satir; i++)
            {
                for (int j = 0; j < Sutun; j++)
                {
                    var h = Hucreler[i, j];
                    if (!h.MayinVar && !h.Acildi)
                        return false;
                }
            }
            return true;
        }
    }

}
