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
    public partial class frmSiparisRapor : Form
    {
        public frmSiparisRapor()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();

        private void LoadChartData()
        {
            string query = @"
                SELECT 
                    CONVERT(DATE, siparisTarihi, 104) AS SiparisTarihi,
                    COUNT(s.siparisID) AS SiparisSayisi,
                    SUM(sd.toplamFiyat) AS ToplamTutar
                FROM 
                    tblSiparisler s
                INNER JOIN 
                    tblSiparisDetaylari sd ON s.siparisID = sd.siparisID
                GROUP BY 
                    CONVERT(DATE, siparisTarihi, 104)
                ORDER BY 
                    SiparisTarihi";

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
            // Seriler oluştur
            Series seriesSiparisSayisi = new Series("Sipariş Sayısı", ViewType.Bar);
            Series seriesToplamTutar = new Series("Toplam Tutar", ViewType.Line);

            foreach (DataRow row in dt.Rows)
            {
                DateTime tarih = Convert.ToDateTime(row["SiparisTarihi"]);
                int siparisSayisi = Convert.ToInt32(row["SiparisSayisi"]);
                decimal toplamTutar = Convert.ToDecimal(row["ToplamTutar"]);

                // Verileri serilere ekle
                seriesSiparisSayisi.Points.Add(new SeriesPoint(tarih, siparisSayisi));
                seriesToplamTutar.Points.Add(new SeriesPoint(tarih, toplamTutar));
            }

            // ChartControl'e serileri ekle
            chartControl1.Series.Clear();
            chartControl1.Series.Add(seriesSiparisSayisi);
            chartControl1.Series.Add(seriesToplamTutar);

            // Ekseni ayarla
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisX.DateTimeScaleOptions.AggregateFunction = AggregateFunction.Sum;
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;

            // Grafiği yeniden çiz
            chartControl1.Refresh();
        }
    
        private void frmGunlukSiparisRapor_Load(object sender, EventArgs e)
        {
            LoadChartData();
        }
    }
}
