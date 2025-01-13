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
using DevExpress.XtraCharts;

namespace restaurantOtomasyonu
{
    public partial class frmGunlukSiparisRaporu : Form
    {
        public frmGunlukSiparisRaporu()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        private void LoadChartData()
        {
            // Bugün yapılan satışları sorgulayan SQL
            string query = @"
                SELECT 
                    u.urunAdi,
                    SUM(sd.adet) AS ToplamAdet
                FROM 
                    tblSiparisler s
                INNER JOIN 
                    tblSiparisDetaylari sd ON s.siparisID = sd.siparisID
                INNER JOIN 
                    tblUrunler u ON sd.urunID = u.urunID
                WHERE 
                    CONVERT(DATETIME, s.siparisTarihi, 104) >= CAST(GETDATE() AS DATE)  -- Bugün
                GROUP BY 
                    u.urunAdi
                ORDER BY 
                    ToplamAdet DESC";

            try
            {
                // Veritabanından veri çekme
                using (SqlDataAdapter da = new SqlDataAdapter(query, bgl.baglan()))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Veriyi ChartControl'e bağlama
                    BindChart(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindChart(DataTable dt)
        {
            // Yeni bir seri oluştur: Ürün Adı ve Toplam Adet
            Series seriesUrunSatislari = new Series("Bugün Satılan Ürünler", ViewType.Bar);

            foreach (DataRow row in dt.Rows)
            {
                string urunAdi = row["urunAdi"].ToString();
                int toplamAdet = Convert.ToInt32(row["ToplamAdet"]);

                // Verileri seriye ekle
                seriesUrunSatislari.Points.Add(new SeriesPoint(urunAdi, toplamAdet));
            }

            // ChartControl'e seriyi ekle
            chartControl1.Series.Clear();
            chartControl1.Series.Add(seriesUrunSatislari);

            // Y ekseninin başlığı
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new ChartTitle { Text = "Bugün Satılan Ürünler" });

            // Grafiği yeniden çiz
            chartControl1.Refresh();
        }
        private void frmGunlukSiparisRaporu_Load(object sender, EventArgs e)
        {
            LoadChartData();
        }
    }
}
