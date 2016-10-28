using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDDUKKAN
{
    public class Baglanti
    {
        public static string conn
        {
            get { return @"Server=DESKTOP-0468O49\SQL2015;Database=Magaza;UID=sa;PWD=123;MultipleActiveResultSets=true"; }
        }
    }
}
