using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace restaurantOtomasyonu
{
    public partial class frmAylikCiro : Form
    {
        public frmAylikCiro()
        {
            InitializeComponent();
        }

        baglanti bgl = new baglanti();

        public void AylikCiroyuGoster()
        {
            string query = @"
    SELECT 
        CONVERT(VARCHAR(7), s.siparisTarihi, 120) AS Ay, 
        SUM(sd.toplamFiyat) AS Ciro 
    FROM 
        tblSiparisler s
    INNER JOIN 
        tblSiparisDetaylari sd ON s.siparisID = sd.siparisID
    GROUP BY 
        CONVERT(VARCHAR(7), s.siparisTarihi, 120)
    ORDER BY 
        CONVERT(VARCHAR(7), s.siparisTarihi, 120)";

            DataTable dt = new DataTable();
            using (SqlConnection conn = bgl.baglan())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            // Mevcut ChartControl kullanımı
            chartControl1.Series.Clear(); // Eski verileri temizle

            // Series oluştur
            Series series = new Series("Aylık Ciro", ViewType.Bar);
            series.DataSource = dt;
            series.ArgumentDataMember = "Ay";
            series.ValueDataMembers.AddRange("Ciro");

            // Series'i ChartControl'e ekle
            chartControl1.Series.Add(series);

            // Diagram nesnesi için güvenli tip dönüştürme
            if (chartControl1.Diagram is XYDiagram diagram)
            {
                diagram.AxisX.Title.Text = "Ay";
                diagram.AxisX.Title.Visible = true;
                diagram.AxisX.Label.Angle = -45; // Etiketi eğmek için
                diagram.AxisY.Title.Text = "Ciro";
                diagram.AxisY.Title.Visible = true;
            }

            // ChartControl başlığı
            chartControl1.Titles.Clear(); // Eski başlıkları temizle
            chartControl1.Titles.Add(new ChartTitle { Text = "Aylık Ciro Grafiği" });

            // Legend görünürlüğü
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
        }

        private void frmAylikCiro_Load(object sender, EventArgs e)
        {
            AylikCiroyuGoster();
        }
    }
}
