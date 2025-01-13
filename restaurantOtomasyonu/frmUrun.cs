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
    public partial class frmUrun : Form
    {
        public frmUrun()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();

        public void Temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtFiyat.Text = "";
            txtStokMiktari.Text = "";
            cmbKategori.Text = "";
        }
        public void cmbVeriCek()
        {
            string cmd = "Select kategoriAdi from tblKategoriler";
            SqlCommand komut = new SqlCommand(cmd, bgl.baglan());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbKategori.Properties.Items.Add(dr["kategoriAdi"].ToString());
            }
            bgl.baglan().Close();
        }
        public void Listele()
        {
            string cmd = "Select tblUrunler.urunID, TblUrunler.urunAdi, TblUrunler.fiyat, TblUrunler.stokMiktari, tblKategoriler.kategoriAdi from TblUrunler, tblKategoriler where tblUrunler.kategoriID=tblKategoriler.KategoriID";
            SqlDataAdapter da = new SqlDataAdapter(cmd, bgl.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            Temizle();
        }
        public void urunEkle()
        {
            SqlCommand komut = new SqlCommand("insert into tblUrunler (urunAdi, fiyat, stokMiktari, kategoriID) values (@p1, @p2, @p3, @p4)", bgl.baglan());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2",decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p3", int.Parse(txtStokMiktari.Text));
            komut.Parameters.AddWithValue("@p4", cmbKategori.SelectedIndex + 1);
            komut.ExecuteNonQuery();
            bgl.baglan().Close();
            Listele();
            Temizle();
        }

        public void bilgiCek()
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("urunID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("urunAdi").ToString();
            txtFiyat.Text = gridView1.GetFocusedRowCellValue("fiyat").ToString();
            txtStokMiktari.Text = gridView1.GetFocusedRowCellValue("stokMiktari").ToString();
            cmbKategori.Text = gridView1.GetFocusedRowCellValue("kategoriAdi").ToString();
        }

        public void urunGuncelle()
        {
            string id = gridView1.GetFocusedRowCellValue("urunID").ToString();
            DialogResult onay = MessageBox.Show(id + " nolu ürünü güncellemek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("update tblUrunler set urunAdi=@p1, fiyat=@p2, stokMiktari=@p3, kategoriID=@p4 where urunID=@p5", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", txtAd.Text);
                komut.Parameters.AddWithValue("@p2", decimal.Parse(txtFiyat.Text));
                komut.Parameters.AddWithValue("@p3", int.Parse(txtStokMiktari.Text));
                komut.Parameters.AddWithValue("@p4", cmbKategori.SelectedIndex + 1);
                komut.Parameters.AddWithValue("@p5", int.Parse(id));
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                Listele();
                Temizle();
            }
        }

        public void urunSil()
        {
            DialogResult onay = MessageBox.Show(txtID.Text + " nolu ürünü silmek istediğinize emin misiniz? ", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from tblUrunler where urunID = @p1", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", int.Parse(txtID.Text));
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                Listele();
                Temizle();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Listele();
            cmbVeriCek();
            Temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            urunEkle();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            bilgiCek();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            urunGuncelle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            urunSil();
        }
    }
}
