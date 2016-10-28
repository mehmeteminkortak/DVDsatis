using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDDUKKAN.Nesneler
{
    public class Musteri
    {
        public int ID { get; set; }
        public string MusteriAdi { get; set; }
        public string MusteriSoyadi { get; set; }
        public string Adres { get; set; }
        public string Tel { get; set; }

        public override string ToString() => $"{MusteriAdi}  {MusteriSoyadi}";
    }
}
