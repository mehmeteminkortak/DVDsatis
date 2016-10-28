using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDDUKKAN.Nesneler
{
    public class Raf
    {
        public int ID { get; set; }
        public string RafAdi { get; set; }
        public string Aciklama { get; set; }
        public override string ToString() => $"{RafAdi}";
    }
}
