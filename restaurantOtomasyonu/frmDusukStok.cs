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
    public partial class frmDusukStok : Form
    {
        public frmDusukStok()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();

        public void dusukStokListele()
        {
            string cmd = "select * from tblUrunler where stokMiktari < 10";
            SqlDataAdapter da = new SqlDataAdapter(cmd,bgl.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }
        private void frmDusukStok_Load(object sender, EventArgs e)
        {
            dusukStokListele();
        }
        private void LoadLowStockProducts(int stockLimit)
        {
            string query = @"
                SELECT 
                    urunID, 
                    urunAdi, 
                    fiyat, 
                    stokMiktari, 
                    kategoriID 
                FROM 
                    tblUrunler 
                WHERE 
                    stokMiktari < @stockLimit";

            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, bgl.baglan()))
                {
                    da.SelectCommand.Parameters.AddWithValue("@stockLimit", stockLimit);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show($"Stok miktarı {stockLimit}'dan düşük ürün bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGoster_Click(object sender, EventArgs e)
        {
            // Seçili RadioButton'a göre stok miktarını belirle
            int stockLimit = 0;

            if (radio10.Checked)
            {
                stockLimit = 10;
            }
            else if (radio20.Checked)
            {
                stockLimit = 20;
            }
            else if (radio30.Checked)
            {
                stockLimit = 30;
            }
            else
            {
                MessageBox.Show("Lütfen bir stok sınırı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Stok miktarına göre ürünleri yükle
            LoadLowStockProducts(stockLimit);
        }
    }
}
