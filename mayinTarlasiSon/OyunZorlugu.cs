using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mayinTarlasiSon
{
    public abstract class OyunZorlugu
    {
        public abstract int Satir { get; }
        public abstract int Sutun { get; }
        public abstract int MayinSayisi { get; }
    }
    public class KolayZorluk : OyunZorlugu
    {
        public override int Satir => 5;
        public override int Sutun => 5;
        public override int MayinSayisi => 8;
    }

    public class OrtaZorluk : OyunZorlugu
    {
        public override int Satir => 16;
        public override int Sutun => 16;
        public override int MayinSayisi => 40;
    }

    public class ZorZorluk : OyunZorlugu
    {
        public override int Satir => 16;
        public override int Sutun => 30;
        public override int MayinSayisi => 99;
    }

}
