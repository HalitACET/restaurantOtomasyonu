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
    public partial class frmUrunSatisRaporu : Form
    {
        public frmUrunSatisRaporu()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        private void LoadChartData()
        {
            string query = @"
                SELECT 
                    u.urunAdi, 
                    SUM(sd.adet) AS ToplamAdet
                FROM 
                    tblSiparisDetaylari sd
                INNER JOIN 
                    tblUrunler u ON sd.urunID = u.urunID
                GROUP BY 
                    u.urunAdi
                ORDER BY 
                    ToplamAdet DESC";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, bgl.baglan()))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // ChartControl'e veri bağlama
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
            // Yeni bir seri oluştur: Ürün Adı ve Satış Adedi
            Series seriesUrunSatis = new Series("Ürün Satış Adedi", ViewType.Bar);

            foreach (DataRow row in dt.Rows)
            {
                string urunAdi = row["urunAdi"].ToString();
                int toplamAdet = Convert.ToInt32(row["ToplamAdet"]);

                // Verileri seriye ekle
                seriesUrunSatis.Points.Add(new SeriesPoint(urunAdi, toplamAdet));
            }

            // ChartControl'e seriyi ekle
            chartControl1.Series.Clear();
            chartControl1.Series.Add(seriesUrunSatis);

            // Y ekseninin başlığı
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new ChartTitle { Text = "Ürün Bazında Satış Adetleri" });

            // Grafiği yeniden çiz
            chartControl1.Refresh();
        }
        private void frmUrunSatisRaporu_Load(object sender, EventArgs e)
        {
            LoadChartData();
        }
    }
}
