using DVDDUKKAN.Nesneler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDDUKKAN
{
    public partial class frmDvdGiris : Form
    {
        public frmDvdGiris()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(Baglanti.conn);
        private void frmDvdGiris_Load(object sender, EventArgs e)
        {
            KategoriDoldur.KategorileriGetirCombo(cmbKategori);
            RaflariGetir(cmbRaf);
        }
        private void RaflariGetir(ComboBox combo)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select * from Raf", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Raf rf = new Raf()
                            {
                                ID = Convert.ToInt32(dr["RafID"]),
                                RafAdi = dr["RafAdi"].ToString(),
                                Aciklama = dr["Aciklama"].ToString()
                            };
                            combo.Items.Add(rf);
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
    
        private void KategorileriGetir(ComboBox combo)
        {
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
        string imgYolu;
        private void btnResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Filter = "jpg Dosyası |*.jpg| png Dosyası|*.png";
            file.ShowDialog();
            txtimajYolu.Text = file.FileName;
            imgYolu = @"Resimler\"+file.SafeFileName;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bool sonuc = false;
            int durum=1;
            if (!rdDurum.Checked)
                durum = 4;
            try
            {
                if (cn.State==ConnectionState.Closed)
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Dvd (DvdAdi,Aciklama,DvdImajYolu,RafID,KategoriID,DurumID) VALUES(@DvdAdi,@Aciklama,@DvdImajYolu,@RaffID,@KategorriID,@DurummID)", cn);
                    cmd.Parameters.AddWithValue("@DvdAdi",txtAd.Text);
                    cmd.Parameters.AddWithValue("@Aciklama",txtAciklama.Text);
                    cmd.Parameters.AddWithValue("@DvdImajYolu",imgYolu);
                    cmd.Parameters.AddWithValue("@RaffID",(cmbRaf.SelectedItem as Raf).ID);
                    cmd.Parameters.AddWithValue("@KategorriID",(cmbKategori.SelectedItem as Kategori).ID);
                    cmd.Parameters.AddWithValue("@DurummID",durum);
                    sonuc= cmd.ExecuteNonQuery()>0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(sonuc ? "Ürün Ekleme işlemi Başarı ile Gerçekleşti." : "Ekleme sırasında bir hata oluştu.", "Ekleme Bildirimi", MessageBoxButtons.OK, sonuc ? MessageBoxIcon.Information : MessageBoxIcon.Stop);
                txtAciklama.Text = string.Empty;
                txtAd.Text = string.Empty;
                txtimajYolu.Text = string.Empty;
                cmbKategori.SelectedIndex = -1;
                cmbRaf.SelectedIndex = -1;
                rdDurum.Checked = false;
                cn.Close();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
