using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDDUKKAN.Nesneler
{
    public class Durum
    {
        public int DurumID { get; set; }
        public string DurumAdi { get; set; }
        public override string ToString() => $"{DurumAdi}";
    }
}
