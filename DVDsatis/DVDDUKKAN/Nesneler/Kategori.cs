using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDDUKKAN.Nesneler
{
    public class Kategori
    {
        public int ID { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public override string ToString() => $"{KategoriAdi}";
    }
}
