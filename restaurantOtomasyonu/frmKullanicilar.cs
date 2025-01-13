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
using System.Globalization;
namespace restaurantOtomasyonu
{
    public partial class frmKullanicilar : Form
    {
        public frmKullanicilar()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();

        public void Temizle()
        {
            txtID.Text = "";
            txtAdSoyad.Text = "";
            txtSifre.Text = "";
            txtSifreTekrar.Text = "";
            cmbRol.Text = "";
        }
        public void bilgiCek()
        {
            txtAdSoyad.Text = gridView1.GetFocusedRowCellValue("kullaniciAdiSoyadi").ToString();
            txtSifre.Text = gridView1.GetFocusedRowCellValue("sifre").ToString();
            cmbRol.Text = gridView1.GetFocusedRowCellValue("rol").ToString();
            txtID.Text = gridView1.GetFocusedRowCellValue("kullaniciID").ToString();
        }
        
        public void Listele()
        {
            string cmd = "Select * from tblKullanicilar";
            SqlDataAdapter da = new SqlDataAdapter(cmd, bgl.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
        public void kullaniciEkle()
        {
            if (txtSifre.Text == txtSifreTekrar.Text)
            {
                DateTime simdikiZaman = DateTime.Now;
                CultureInfo turkceKultur = new CultureInfo("tr-TR");
                SqlCommand komut = new SqlCommand("insert into tblKullanicilar (kullaniciAdiSoyadi,sifre,rol,olusturulmaTarihi) values (@p1,@p2,@p3,@p4)", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.Parameters.AddWithValue("@p3", cmbRol.SelectedItem);
                komut.Parameters.AddWithValue("@p4", simdikiZaman.ToString("f", turkceKultur));
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                Listele();
                Temizle();
            }
            else
            {
                MessageBox.Show("Şifre tekrarı yanlış girdiniz!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        public void kullaniciGuncelle()
        {
            DialogResult onay = MessageBox.Show(txtID.Text + " nolu kullanıcının bilgilerini güncellemek istediğinize emin misiniz? ", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("update tblKullanicilar set kullaniciAdiSoyadi=@p1, sifre=@p2, rol=@p3 where kullaniciID=@p4", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", txtID.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.Parameters.AddWithValue("@p3", cmbRol.SelectedItem);
                komut.Parameters.AddWithValue("@p4", int.Parse(txtID.Text));
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                Listele();
                Temizle();
            }
        }
        public void kullaniciSil()
        {
            DialogResult onay = MessageBox.Show(txtID.Text + " nolu kullanıcıyı silmek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete from tblKullanicilar where kullaniciID=@p1", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", int.Parse(txtID.Text));
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                Listele();
                Temizle();
            }
        }

        private void frmKullanicilar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            kullaniciEkle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            bilgiCek();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            kullaniciGuncelle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            kullaniciSil();
        }
    }
}
