using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;

namespace restaurantOtomasyonu
{
    public partial class frmSiparisler : Form
    {
        public frmSiparisler()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        public void Temizle()
        {
            txtAdet.Text = "";
            txtMasaAdi.Text = "";
            txtMasaID.Text = "";
            txtSiparisID.Text = "";
            txtToplamFiyat.Text = "";
            txtUrunAdi.Text = "";
            txtUrunID.Text = "";
            radioHazir.Checked = false;
            radioHazirlaniyor.Checked = false;
        }
        private void SiparisDetaylariniYukle()
        {
            string query = @"
    SELECT 
        s.siparisID,
        m.masaID,
        sd.urunID,
        m.masaAdi AS MasaAdi,
        s.durum AS SiparisDurumu,
        s.siparisTarihi AS SiparisTarihi,
        u.urunAdi AS UrunAdi,
        sd.adet AS UrunAdeti,
        sd.toplamFiyat AS ToplamFiyat
    FROM 
        tblSiparisler s
    INNER JOIN 
        tblMasalar m ON s.masaID = m.masaID
    INNER JOIN 
        tblSiparisDetaylari sd ON s.siparisID = sd.siparisID
    INNER JOIN 
        tblUrunler u ON sd.urunID = u.urunID";

            using (SqlDataAdapter da = new SqlDataAdapter(query, bgl.baglan()))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl3.DataSource = dt;
            }
        }

        public void SiparisVeDetayEkle()
        {
            using (SqlConnection conn = bgl.baglan())
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Sipariş Ekle
                    SqlCommand komut1 = new SqlCommand(
                        "INSERT INTO tblSiparisler (masaID, durum, siparisTarihi) OUTPUT INSERTED.siparisID VALUES (@p1, @p2, @p3);", conn, transaction);
                    komut1.Parameters.AddWithValue("@p1", txtMasaID.Text);
                    komut1.Parameters.AddWithValue("@p2", radioHazirlaniyor.Checked ? "False" : "True");
                    komut1.Parameters.AddWithValue("@p3", txtSiparisTarihi.Text);
                    int siparisID = (int)komut1.ExecuteScalar();

                    // Sipariş Detayları Ekle
                    SqlCommand komut2 = new SqlCommand(
                        "INSERT INTO tblSiparisDetaylari (siparisID, urunID, adet, toplamFiyat) VALUES (@p1, @p2, @p3, @p4);", conn, transaction);
                    komut2.Parameters.AddWithValue("@p1", siparisID);
                    komut2.Parameters.AddWithValue("@p2", txtUrunID.Text);
                    komut2.Parameters.AddWithValue("@p3", txtAdet.Text);
                    komut2.Parameters.AddWithValue("@p4", decimal.Parse(txtToplamFiyat.Text));
                    komut2.ExecuteNonQuery();

                    // Stok Miktarını Güncelle
                    SqlCommand komut3 = new SqlCommand(
                        "UPDATE tblUrunler SET stokMiktari = stokMiktari - @p1 WHERE urunID = @p2;", conn, transaction);
                    komut3.Parameters.AddWithValue("@p1", txtAdet.Text);
                    komut3.Parameters.AddWithValue("@p2", txtUrunID.Text);
                    komut3.ExecuteNonQuery();

                    // Masa Durumunu Güncelle (Eğer "False" ise "True" yap)
                    SqlCommand komut4 = new SqlCommand(
                        "UPDATE tblMasalar SET durum = 'True' WHERE masaID = @p1 AND durum = 'False';", conn, transaction);
                    komut4.Parameters.AddWithValue("@p1", txtMasaID.Text);
                    komut4.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Hata: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void SiparisVeDetayGuncelle()
        {
            DialogResult onay = MessageBox.Show("Güncelleme yapmak istediğinize emin misiniz?","Onay Kutusu",MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                using (SqlConnection conn = bgl.baglan())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Sipariş Güncelle
                        SqlCommand komut1 = new SqlCommand(
                            "UPDATE tblSiparisler SET masaID = @p1, durum = @p2, siparisTarihi = @p3 WHERE siparisID = @p4;", conn, transaction);
                        komut1.Parameters.AddWithValue("@p1", txtMasaID.Text);
                        komut1.Parameters.AddWithValue("@p2", radioHazirlaniyor.Checked ? "False" : "True");
                        komut1.Parameters.AddWithValue("@p3", txtSiparisTarihi.Text);
                        komut1.Parameters.AddWithValue("@p4", txtSiparisID.Text);
                        komut1.ExecuteNonQuery();

                        // Mevcut adet bilgisini al
                        SqlCommand komutGetAdet = new SqlCommand(
                            "SELECT adet FROM tblSiparisDetaylari WHERE siparisID = @p1 AND urunID = @p2;", conn, transaction);
                        komutGetAdet.Parameters.AddWithValue("@p1", txtSiparisID.Text);
                        komutGetAdet.Parameters.AddWithValue("@p2", txtUrunID.Text);

                        int eskiAdet = (int)komutGetAdet.ExecuteScalar();

                        // Sipariş Detayları Güncelle
                        SqlCommand komut2 = new SqlCommand(
                            "UPDATE tblSiparisDetaylari SET urunID = @p1, adet = @p2, toplamFiyat = @p3 WHERE siparisID = @p4;", conn, transaction);
                        komut2.Parameters.AddWithValue("@p1", txtUrunID.Text);
                        komut2.Parameters.AddWithValue("@p2", txtAdet.Text);
                        komut2.Parameters.AddWithValue("@p3", decimal.Parse(txtToplamFiyat.Text));
                        komut2.Parameters.AddWithValue("@p4", txtSiparisID.Text);
                        komut2.ExecuteNonQuery();

                        // Stok Miktarını Güncelle
                        int yeniAdet = int.Parse(txtAdet.Text);
                        int fark = yeniAdet - eskiAdet; // Yeni adet ve eski adet farkını hesapla

                        SqlCommand komut3 = new SqlCommand(
                            "UPDATE tblUrunler SET stokMiktari = stokMiktari - @p1 WHERE urunID = @p2;", conn, transaction);
                        komut3.Parameters.AddWithValue("@p1", fark);
                        komut3.Parameters.AddWithValue("@p2", txtUrunID.Text);
                        komut3.ExecuteNonQuery();

                        // İşlemleri onayla
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Hata: {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
        }


        public void SiparisVeDetaySil()
        {
            DialogResult onay = MessageBox.Show("Silme işlemi yapmak istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                using (SqlConnection conn = bgl.baglan())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Stok Miktarını Güncelle
                        SqlCommand komut1 = new SqlCommand(
                            "UPDATE tblUrunler SET stokMiktari = stokMiktari + (SELECT adet FROM tblSiparisDetaylari WHERE siparisID = @p1) WHERE urunID = (SELECT urunID FROM tblSiparisDetaylari WHERE siparisID = @p1);", conn, transaction);
                        komut1.Parameters.AddWithValue("@p1", txtSiparisID.Text);
                        komut1.ExecuteNonQuery();

                        // Sipariş Detayları Sil
                        SqlCommand komut2 = new SqlCommand(
                            "DELETE FROM tblSiparisDetaylari WHERE siparisID = @p1;", conn, transaction);
                        komut2.Parameters.AddWithValue("@p1", txtSiparisID.Text);
                        komut2.ExecuteNonQuery();

                        // Sipariş Sil
                        SqlCommand komut3 = new SqlCommand(
                            "DELETE FROM tblSiparisler WHERE siparisID = @p1;", conn, transaction);
                        komut3.Parameters.AddWithValue("@p1", txtSiparisID.Text);
                        komut3.ExecuteNonQuery();

                        // Masa Durumunu Güncelle (Eğer o masaya ait başka sipariş yoksa)
                        SqlCommand komut4 = new SqlCommand(
                            "IF NOT EXISTS (SELECT 1 FROM tblSiparisler WHERE masaID = @p1) UPDATE tblMasalar SET durum = 'False' WHERE masaID = @p1;", conn, transaction);
                        komut4.Parameters.AddWithValue("@p1", txtMasaID.Text);
                        komut4.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Hata: {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }


        private void MasalariYukle()
        {
            string query = "SELECT * FROM tblMasalar";
            using (SqlDataAdapter da = new SqlDataAdapter(query, bgl.baglan()))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
        }
        private void UrunleriYukle()
        {
            string query = @"
        SELECT 
            u.urunID, 
            u.urunAdi, 
            u.fiyat, 
            u.stokMiktari, 
            k.kategoriAdi 
        FROM 
            tblUrunler u
        LEFT JOIN 
            tblKategoriler k ON u.kategoriID = k.kategoriID";
            using (SqlDataAdapter da = new SqlDataAdapter(query, bgl.baglan()))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl2.DataSource = dt;
            }
        }
        private void frmSiparisler_Load(object sender, EventArgs e)
        {
            
            DateTime simdikiZaman = DateTime.Now;
            
            MasalariYukle();
            UrunleriYukle();
            SiparisDetaylariniYukle();
            gridView3.Columns["siparisID"].Visible = false;
            gridView3.Columns["masaID"].Visible = false;
            gridView3.Columns["urunID"].Visible = false;
            txtSiparisTarihi.Text = simdikiZaman.ToString();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtMasaID.Text = gridView1.GetFocusedRowCellValue("masaID")?.ToString();
            txtMasaAdi.Text = gridView1.GetFocusedRowCellValue("masaAdi")?.ToString();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtUrunID.Text = gridView2.GetFocusedRowCellValue("urunID")?.ToString();
            txtUrunAdi.Text = gridView2.GetFocusedRowCellValue("urunAdi")?.ToString();
            //txtToplamFiyat.Text = gridView2.GetFocusedRowCellValue("fiyat")?.ToString();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            SiparisVeDetayEkle();
            SiparisDetaylariniYukle();
            UrunleriYukle();
            MasalariYukle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SiparisVeDetayGuncelle();
            SiparisDetaylariniYukle();
            UrunleriYukle();
            MasalariYukle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SiparisVeDetaySil();
            SiparisDetaylariniYukle();
            UrunleriYukle();
            MasalariYukle();
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtSiparisID.Text =gridView3.GetFocusedRowCellValue("siparisID")?.ToString();
            txtMasaID.Text = gridView3.GetFocusedRowCellValue("masaID")?.ToString();
            txtUrunID.Text = gridView3.GetFocusedRowCellValue("urunID")?.ToString();
            txtMasaAdi.Text = gridView3.GetFocusedRowCellValue("MasaAdi")?.ToString();
            txtSiparisTarihi.Text = gridView3.GetFocusedRowCellValue("SiparisTarihi")?.ToString();
            txtUrunAdi.Text = gridView3.GetFocusedRowCellValue("UrunAdi")?.ToString();
            txtAdet.Text = gridView3.GetFocusedRowCellValue("UrunAdeti")?.ToString();
            //txtToplamFiyat.Text = gridView3.GetFocusedRowCellValue("ToplamFiyat")?.ToString();
            if (gridView3.GetFocusedRowCellValue("SiparisDurumu")?.ToString() == "True")
            {
                radioHazir.Checked = true;
                radioHazirlaniyor.Checked = false;
            }
            else if (gridView3.GetFocusedRowCellValue("SiparisDurumu")?.ToString() == "False")
            {
                radioHazirlaniyor.Checked = true;
                radioHazir.Checked = false;
            }
        }

        private void txtAdet_Properties_ValueChanged(object sender, EventArgs e)
        {
            // Ürünün fiyatını al
            decimal urunFiyati;
            if (decimal.TryParse(gridView2.GetFocusedRowCellValue("fiyat")?.ToString(), out urunFiyati))
            {
                // SpinEdit'ten adet bilgisini al
                int urunAdeti = (int)txtAdet.Value;

                // Toplam fiyatı hesapla
                decimal toplamFiyat = urunAdeti * urunFiyati;

                // Toplam fiyatı TextEdit'e yaz
                txtToplamFiyat.Text = toplamFiyat.ToString();
            }
            else
            {
                MessageBox.Show("Geçerli bir fiyat giriniz.");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
