using DVDDUKKAN.Nesneler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDDUKKAN
{
    public class KategoriDoldur
    {
        public static void KategorileriGetirCombo(ComboBox combo)
        {
            SqlConnection cn = new SqlConnection(Baglanti.conn);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select * from Kategori", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Kategori ktg = new Kategori()
                            {
                                ID = Convert.ToInt32(dr["KategoriID"]),
                                KategoriAdi = dr["KategoriAdi"].ToString(),
                                Aciklama = dr["Aciklama"].ToString()
                            };
                            combo.Items.Add(ktg);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { cn.Close(); }
        }
    }
}
