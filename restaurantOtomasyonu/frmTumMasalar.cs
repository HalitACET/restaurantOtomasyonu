using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace restaurantOtomasyonu
{
    public partial class frmTumMasalar : Form
    {
        public frmTumMasalar()
        {
            InitializeComponent();
        }

        baglanti bgl = new baglanti(); // Veritabanı bağlantı sınıfı

        private void Masalar_Load(object sender, EventArgs e)
        {
            string query = @"
SELECT 
    m.masaID, 
    m.masaAdi AS [Masa Adı],
    m.durum AS MasaDurumu,
    ISNULL(STUFF((
        SELECT ', ' + u.urunAdi + ' (' + CAST(sd.adet AS VARCHAR) + ')'
        FROM tblSiparisDetaylari sd
        INNER JOIN tblUrunler u ON sd.urunID = u.urunID
        WHERE sd.siparisID IN (SELECT s.siparisID FROM tblSiparisler s WHERE s.masaID = m.masaID)
        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, ''), 'Sipariş Yok') AS [Ürünler ve Adetleri],
    ISNULL((
        SELECT SUM(sd.adet * u.fiyat)
        FROM tblSiparisDetaylari sd
        INNER JOIN tblUrunler u ON sd.urunID = u.urunID
        INNER JOIN tblSiparisler s ON sd.siparisID = s.siparisID
        WHERE s.masaID = m.masaID
    ), 0) AS [Toplam Fiyat],
    CASE 
        WHEN MAX(CAST(s.siparisID AS INT)) IS NULL THEN 'Sipariş Yok'
        ELSE 'Sipariş Var'
    END AS [Sipariş Durumu],
    CASE 
        WHEN MAX(CAST(s.durum AS INT)) = 1 THEN 'Tamamlandı'
        WHEN MAX(CAST(s.durum AS INT)) = 0 THEN 'Hazırlanıyor'
        ELSE 'Sipariş Yok'
    END AS [Sipariş Durum],
    MAX(rm.RezerveZamani) AS [Rezerve Zamanı]
FROM 
    tblMasalar m
LEFT JOIN 
    tblSiparisler s ON m.masaID = s.masaID
LEFT JOIN 
    tblRezerveMasalar rm ON m.masaID = rm.masaID
GROUP BY 
    m.masaID, m.masaAdi, m.durum;
";

            using (SqlCommand komut = new SqlCommand(query, bgl.baglan()))
            {
                using (SqlDataReader reader = komut.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Verileri oku
                        string siparisDurumu = reader["Sipariş Durumu"].ToString();
                        string siparisDurum = reader["Sipariş Durum"].ToString();
                        bool masaDurumu = (bool)reader["MasaDurumu"];
                        string rezerveZamani = reader["Rezerve Zamanı"] != DBNull.Value
                            ? $"Rezerve Zamanı: {reader["Rezerve Zamanı"]}"
                            : "";

                        // Buton metni
                        string buttonText = $"Masa Adı: {reader["Masa Adı"]}\n" +
                                            $"Ürünler: {reader["Ürünler ve Adetleri"]}\n" +
                                            $"Toplam Fiyat: {reader["Toplam Fiyat"]}\n" +
                                            $"Sipariş Durumu: {siparisDurumu}\n" +
                                            $"Sipariş Durum: {siparisDurum}\n" +
                                            $"{rezerveZamani}\n" +
                                            $"{(masaDurumu ? "Dolu" : "Boş")}";

                        // Yeni buton oluştur
                        Button yeniMasaButton = new Button
                        {
                            Text = buttonText,
                            Width = 220,
                            Height = 120,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Padding = new Padding(5),
                            BackColor = masaDurumu ? Color.Red : Color.Green
                        };

                        // Butonun tıklanma olayını tanımla
                        yeniMasaButton.Click += YeniMasaButton_Click;
                        flowLayoutPanel1.Controls.Add(yeniMasaButton);
                    }
                }
            }
        }

        private void YeniMasaButton_Click(object sender, EventArgs e)
        {
            // Tıklanan butonun bilgilerini göster
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                MessageBox.Show(clickedButton.Text);
            }
        }
    }
}
