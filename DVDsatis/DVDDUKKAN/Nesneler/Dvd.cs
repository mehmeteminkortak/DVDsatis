using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDDUKKAN.Nesneler
{
    public class Dvd
    {
        public int ID { get; set; }
        public string DvdAdi { get; set; }
        public string Aciklama { get; set; }
        public string DvdImajYolu { get; set; }
        public Raf RafID { get; set; }
        public Kategori KategoriID { get; set; }
        public Durum DurumID { get; set; }
        
    }
}
