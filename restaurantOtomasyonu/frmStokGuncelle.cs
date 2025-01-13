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
    public partial class frmStokGuncelle : Form
    {
        public frmStokGuncelle()
        {
            InitializeComponent();
        }

        baglanti bgl = new baglanti();
        public void bilgiCek()
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("urunID").ToString();
            txtStok.Text = gridView1.GetFocusedRowCellValue("stokMiktari").ToString();
        }
        public void Temizle()
        {
            txtID.Text = "";
            txtStok.Text = "";
        }
        public void Listele()
        {
            string cmd = "Select tblUrunler.urunID, TblUrunler.urunAdi, TblUrunler.fiyat, TblUrunler.stokMiktari, tblKategoriler.kategoriAdi from TblUrunler, tblKategoriler where tblUrunler.kategoriID=tblKategoriler.KategoriID";
            SqlDataAdapter da = new SqlDataAdapter(cmd, bgl.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        public void StokGuncelle()
        {
            DialogResult onay = MessageBox.Show(txtID.Text + " nolu ürünün stoğunu güncellemek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("update tblUrunler set stokMiktari=@p1 where urunID=@p2", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", int.Parse(txtStok.Text));
                komut.Parameters.AddWithValue("@p2", int.Parse(txtID.Text));
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                Listele();
                Temizle();
            }
        }

        private void stokGuncelle_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            StokGuncelle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            bilgiCek();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            int stok = int.Parse(txtStok.Text);
            stok += 5;
            txtStok.Text = stok.ToString();
        }
    }
}
