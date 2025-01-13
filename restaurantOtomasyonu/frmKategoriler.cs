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
    public partial class frmKategoriler : Form
    {
        public frmKategoriler()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();

        public void Listele()
        {
            string cmd = "select * from tblKategoriler";
            SqlDataAdapter da = new SqlDataAdapter(cmd, bgl.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
        public void Temizle()
        {
            txtID.Text = "";
            txtKategori.Text = "";
        }
        public void BilgiCek()
        {
            txtID.Text=gridView1.GetFocusedRowCellValue("kategoriID").ToString();
            txtKategori.Text = gridView1.GetFocusedRowCellValue("kategoriAdi").ToString();
        }
        public void kategoriEkle()
        {
            SqlCommand komut = new SqlCommand("insert into tblKategoriler (kategoriAdi) values (@p1)",bgl.baglan());
            komut.Parameters.AddWithValue("@p1",txtKategori.Text);
            komut.ExecuteNonQuery();
            bgl.baglan().Close();
            Listele();
            Temizle();
        }
        public void kategoriGuncelle()
        {
            DialogResult onay = MessageBox.Show(txtID.Text + " nolu kategoriyi güncellemek istediğinize emin misini ?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("update tblKategoriler set kategoriAdi=@p1 where kategoriID=@p2", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", txtKategori.Text);
                komut.Parameters.AddWithValue("@p2", int.Parse(txtID.Text));
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                Listele();
                Temizle();
            }
        }

        public void kategoriSil()
        {
            DialogResult onay = MessageBox.Show(txtID.Text + " nolu kategoriyi silmek istediğinize emin misiniz ?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from tblKategoriler where kategoriID=@p1", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", int.Parse(txtID.Text));
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                Listele();
                Temizle();
            }
        }

        private void frmKategoriler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            kategoriEkle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BilgiCek();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            kategoriGuncelle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            kategoriSil();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
