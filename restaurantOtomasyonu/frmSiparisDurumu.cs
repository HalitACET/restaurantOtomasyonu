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
namespace restaurantOtomasyonu
{
    public partial class frmSiparisDurumu : Form
    {
        public frmSiparisDurumu()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        public void Temizle()
        {
            txtMasaAdi.Text = "";
            txtSiparisID.Text = "";
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
        tblUrunler u ON sd.urunID = u.urunID
    ORDER BY 
        CASE 
            WHEN s.durum = 'False' THEN 0 
            WHEN s.durum = 'True' THEN 1
        END;"; // Önce False, sonra True olanları getir ve sıralar

            using (SqlDataAdapter da = new SqlDataAdapter(query, bgl.baglan()))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt; // GridControl'e veriyi yükle
            }
        }

        public void SiparisVeDetayGuncelle()
        {
            using (SqlConnection conn = bgl.baglan())
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    // Sipariş Güncelle
                    SqlCommand komut1 = new SqlCommand(
                        "UPDATE tblSiparisler SET  durum = @p1 WHERE siparisID = @p2;", conn);
                    komut1.Parameters.AddWithValue("@p1", radioHazirlaniyor.Checked ? "False" : "True");
                    komut1.Parameters.AddWithValue("@p2",txtSiparisID.Text);
                    komut1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        private void frmSiparisDurumu_Load(object sender, EventArgs e)
        {
            SiparisDetaylariniYukle();
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            SiparisVeDetayGuncelle();
            SiparisDetaylariniYukle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtSiparisID.Text = gridView1.GetFocusedRowCellValue("siparisID").ToString();
            txtMasaAdi.Text = gridView1.GetFocusedRowCellValue("MasaAdi").ToString();
        }
    }
}
