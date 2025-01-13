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
using DevExpress.XtraPrinting;

namespace restaurantOtomasyonu
{
    public partial class frmUrunRapor : Form
    {
        public frmUrunRapor()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        private void LoadChartData()
        {
            string query = @"
                SELECT 
                    u.urunAdi, 
                    u.stokMiktari
                FROM 
                    tblUrunler u
                ORDER BY 
                    u.stokMiktari DESC";

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
            // Yeni bir seri oluştur: Ürün Adı ve Stok Miktarı
            Series seriesUrunStok = new Series("Ürün Stok Miktarı", ViewType.Bar);

            foreach (DataRow row in dt.Rows)
            {
                string urunAdi = row["urunAdi"].ToString();
                int stokMiktari = Convert.ToInt32(row["stokMiktari"]);

                // Verileri seriye ekle
                seriesUrunStok.Points.Add(new SeriesPoint(urunAdi, stokMiktari));
            }

            // ChartControl'e seriyi ekle
            chartControl1.Series.Clear();
            chartControl1.Series.Add(seriesUrunStok);

            // Y ekseninin başlığı
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new ChartTitle { Text = "Ürün Bazında Stok Miktarları" });

            // Grafiği yeniden çiz
            chartControl1.Refresh();
        }
        private void ExportToPdf()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Dosyası (*.pdf)|*.pdf";
                saveDialog.Title = "PDF Olarak Kaydet";
                saveDialog.DefaultExt = "pdf";
                saveDialog.FileName = $"UrunStokRaporu_{DateTime.Now.ToString("yyyyMMdd")}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // PDF seçeneklerini ayarla
                    PdfExportOptions pdfOptions = new PdfExportOptions();
                    //pdfOptions.ShowPrintPageDialog = false;
                    pdfOptions.DocumentOptions.Title = "Ürün Stok Raporu";
                    pdfOptions.DocumentOptions.Author = "Restaurant Otomasyonu";
                    pdfOptions.DocumentOptions.Subject = "Ürün Bazında Stok Miktarları";

                    // Grafiği PDF'e aktar
                    chartControl1.ExportToPdf(saveDialog.FileName, pdfOptions);

                    MessageBox.Show("Rapor başarıyla PDF olarak kaydedildi.",
                                  "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken hata oluştu: " + ex.Message,
                               "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUrunRapor_Load(object sender, EventArgs e)
        {
            LoadChartData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ExportToPdf();
        }
    }
}
