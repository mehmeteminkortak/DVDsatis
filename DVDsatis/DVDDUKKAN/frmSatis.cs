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
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(Baglanti.conn);
        private void frmSatis_Load(object sender, EventArgs e)
        {
            KategoriDoldur.KategorileriGetirCombo(cmbKategoriler);
            MusterileriComboyaYukle(cmbMusteriler);
        }
        List<Dvd> dvdler;
        private void DgvDVDdoldur(DataGridView dgv, ComboBox comboKategori)
        {
            //dgv.ColumnCount = 5;
            //dgv.Columns[0].Name = "ADI";
            //dgv.Columns[1].Name = "AÇIKLAMA";
            //dgv.Columns[2].Name = "RAFTAKİ YERİ";
            //dgv.Columns[3].Name = "KATEGORİSİ";
            //dgv.Columns[4].Name = "DURUMU";

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Dvd where KategoriID=@dKategoriID", cn);
                    cmd.Parameters.AddWithValue("@dKategoriID", (comboKategori.SelectedItem as Kategori).ID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dvdler = new List<Dvd>();
                        //int satirNo = 0;
                        while (dr.Read())
                        {
                            //satirNo = dgv.Rows.Add();
                            gelenKategoriDoldur(Convert.ToInt32(dr["KategoriID"]));
                            gelenDurumDoldur(Convert.ToInt32(dr["DurumID"]));
                            gelenRafDoldur(Convert.ToInt32(dr["RafID"]));

                            Dvd dvd = new Dvd()
                            {
                                ID = Convert.ToInt32(dr["DvdID"]),
                                DvdAdi = dr["DvdAdi"].ToString(),
                                Aciklama = dr["Aciklama"].ToString(),
                                DvdImajYolu = dr["DvdImajYolu"].ToString(),
                                DurumID = gelenDurum,
                                KategoriID = gelenKategori,
                                RafID = gelenRaf
                            };
                            dvdler.Add(dvd);
                            //dgv.Rows[satirNo].Cells[0].Value = dvd.DvdAdi.ToString();
                            //dgv.Rows[satirNo].Cells[1].Value = dvd.Aciklama.ToString();
                            //dgv.Rows[satirNo].Cells[2].Value = gelenRaf.RafAdi.ToString();
                            //dgv.Rows[satirNo].Cells[3].Value = gelenKategori.KategoriAdi.ToString();
                            //dgv.Rows[satirNo].Cells[4].Value = gelenDurum.DurumAdi.ToString();
                            //satirNo++;
                        }
                        dgvDvdListe.DataSource = dvdler.ToList();
                        dgv.Columns[0].Visible = false;
                        dgv.Columns[3].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { cn.Close(); }
        }

        private void MusterileriComboyaYukle(ComboBox combo)
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Musteriler", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Musteri mstr = new Musteri()
                            {
                                ID = Convert.ToInt32(dr["MusteriID"]),
                                MusteriAdi = dr["MusteriAdi"].ToString(),
                                MusteriSoyadi = dr["MusteriSoyadi"].ToString(),
                                Adres = dr["Adres"].ToString(),
                                Tel = dr["Tel"].ToString()
                            };
                            combo.Items.Add(mstr);
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
        Kategori gelenKategori;
        private void gelenKategoriDoldur(int ID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Kategori WHERE KategoriID=@ID", cn);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        gelenKategori = new Kategori()
                        {
                            ID = Convert.ToInt32(dr["KategoriID"]),
                            KategoriAdi = dr["KategoriAdi"].ToString(),
                            Aciklama = dr["Aciklama"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Durum gelenDurum;
        private void gelenDurumDoldur(int ID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Durum WHERE DurumID=@ID", cn);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        gelenDurum = new Durum()
                        {
                            DurumID = Convert.ToInt32(dr["DurumID"]),
                            DurumAdi = dr["DurumAdi"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Raf gelenRaf;
        private void gelenRafDoldur(int ID)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("select * from Raf WHERE RafID=@ID", cn);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        gelenRaf = new Raf()
                        {
                            ID = Convert.ToInt32(dr["RafID"]),
                            RafAdi = dr["RafAdi"].ToString(),
                            Aciklama = dr["Aciklama"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Siparis gelenSiparis;
        private void SiparisleriDoldur()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Siparis S ORDER BY S.SiparisID DESC", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            gelenSiparis = new Siparis()
                            {
                                SiparisID = Convert.ToInt32(dr["SiparisID"]),
                                SiparisTarihi = (DateTime)dr["SiparisTarihi"],
                                MusteriID = Convert.ToInt32(dr["MusteriID"])
                            };
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

        private void cmbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvDVDdoldur(dgvDvdListe, cmbKategoriler);
        }
        Dvd secilenDvd;
        private void dgvDvdListe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenDvdSirasi = dgvDvdListe.SelectedRows[0].Index;

            secilenDvd = dvdler[secilenDvdSirasi];

            lblRafBilgisi.Text = secilenDvd.DurumID.DurumAdi;
            pbKapak.ImageLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + secilenDvd.DvdImajYolu;
        }

        private void btnIslem_Click(object sender, EventArgs e)
        {
            int DurumID = 2;
            if (rbSat.Checked)
                DurumID = 3;
            bool sonuc = false;
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    SqlCommand cmdDvdUpdate = new SqlCommand("UPDATE Dvd SET DurumID=@DurumID WHERE DvdID=@DvdID", cn);
                    cmdDvdUpdate.Parameters.AddWithValue("@DvdID", secilenDvd.ID);
                    cmdDvdUpdate.Parameters.AddWithValue("@DurumID", DurumID);
                    sonuc = cmdDvdUpdate.ExecuteNonQuery() > 0;
                    cn.Close();
                }
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    SqlCommand cmdSiparisEkle = new SqlCommand("INSERT INTO Siparis (SiparisTarihi,MusteriID) VALUES (@SiparisTarihi,@MusteriID)", cn);
                    cmdSiparisEkle.Parameters.AddWithValue("@SiparisTarihi", DateTime.Now);
                    cmdSiparisEkle.Parameters.AddWithValue("@MusteriID", (cmbMusteriler.SelectedItem as Musteri).ID);
                    sonuc = cmdSiparisEkle.ExecuteNonQuery() > 0;
                    cn.Close();
                    SiparisleriDoldur();
                }
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    SqlCommand cmdSiparisDetayEkle = new SqlCommand("INSERT INTO SiparisDetay (SiparisID,SatisFiyat,Adet,DvdID) VALUES (@SiparisID,@SatisFiyat,@Adet,@DvdID)", cn);
                    cmdSiparisDetayEkle.Parameters.AddWithValue("@SiparisID",gelenSiparis.SiparisID);
                    cmdSiparisDetayEkle.Parameters.AddWithValue("@SatisFiyat", nmrSatisFiyati.Value);
                    cmdSiparisDetayEkle.Parameters.AddWithValue("@Adet", nmrAdet.Value);
                    cmdSiparisDetayEkle.Parameters.AddWithValue("@DvdID", secilenDvd.ID);
                    sonuc = cmdSiparisDetayEkle.ExecuteNonQuery() > 0;
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show(sonuc ? "Ürün Ekleme işlemi Başarı ile Gerçekleşti." : "Ekleme sırasında bir hata oluştu.", "Ekleme Bildirimi", MessageBoxButtons.OK, sonuc ? MessageBoxIcon.Information : MessageBoxIcon.Stop);

                pbKapak.ImageLocation = string.Empty;
                lblRafBilgisi.Text = string.Empty;
                nmrAdet.Value = nmrAdet.Minimum;
                nmrSatisFiyati.Value = nmrSatisFiyati.Minimum;
                cmbMusteriler.SelectedIndex = -1;
                rbKirala.Checked = false;
                rbSat.Checked = false;

                cn.Close();
            }
        }
    }
}
