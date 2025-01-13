using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace restaurantOtomasyonu
{
    public partial class frmSiparisGecmisi : Form
    {
        public frmSiparisGecmisi()
        {
            InitializeComponent();
        }

        baglanti bgl = new baglanti();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Şu anki zamanı al
            DateTime endDate = DateTime.Now;
            DateTime startDate = endDate;

            // Seçilen tarih aralığına göre başlangıç tarihini hesapla
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Son 1 Saat":
                    startDate = endDate.AddHours(-1);
                    break;
                case "Son 6 Saat":
                    startDate = endDate.AddHours(-6);
                    break;
                case "Son 1 Gün":
                    startDate = endDate.AddDays(-1);
                    break;
                case "Son 3 Gün":
                    startDate = endDate.AddDays(-3);
                    break;
                case "Son 1 Hafta":
                    startDate = endDate.AddDays(-7);
                    break;
                case "Son 2 Hafta":
                    startDate = endDate.AddDays(-14);
                    break;
                case "Son 1 Ay":
                    startDate = endDate.AddMonths(-1);
                    break;
            }

            // Tarihleri SQL Server için uygun formata dönüştür
            string startDateFormatted = startDate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string endDateFormatted = endDate.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            // SQL sorgusunu oluştur
            string query = @"
                SELECT 
                    s.siparisID, 
                    m.masaAdi AS MasaAdi, 
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
                WHERE 
                    CONVERT(DATETIME, s.siparisTarihi, 104) BETWEEN @startDate AND @endDate";

            // Verileri yükle
            using (SqlDataAdapter da = new SqlDataAdapter(query, bgl.baglan()))
            {
                // Parametreleri ekle
                da.SelectCommand.Parameters.AddWithValue("@startDate", startDateFormatted);
                da.SelectCommand.Parameters.AddWithValue("@endDate", endDateFormatted);

                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;

                // Veri bulunamadıysa kullanıcıya bilgi ver
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Seçilen aralıkta veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
