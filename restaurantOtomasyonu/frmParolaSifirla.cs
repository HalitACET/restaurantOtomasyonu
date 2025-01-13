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
    public partial class frmParolaSifirla : Form
    {
        public frmParolaSifirla()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        public void Listele()
        {
            string cmd = "Select * from tblKullanicilar";
            SqlDataAdapter da = new SqlDataAdapter(cmd, bgl.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
        public void Temizle()
        {
            txtAdSoyad.Text = "";
            txtID.Text = "";
            txtSifre.Text = "";
            txtSifreTekrar.Text = "";
        }
        public void parolaSifirla()
        {
            DialogResult onay = MessageBox.Show(txtID.Text + " nolu kullanıcının şifresinin değiştirmek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                if (txtSifre.Text == txtSifreTekrar.Text)
                {
                    SqlCommand komut = new SqlCommand("update tblKullanicilar set sifre=@p1 where kullaniciID=@p2", bgl.baglan());
                    komut.Parameters.AddWithValue("@p1", txtSifre.Text);
                    komut.Parameters.AddWithValue("@p2", int.Parse(txtID.Text));
                    komut.ExecuteNonQuery();
                    bgl.baglan().Close();
                    Listele();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Şifre tekrarı yanlış girdiniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void frmParolaSifirla_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            parolaSifirla();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtAdSoyad.Text = gridView1.GetFocusedRowCellValue("kullaniciAdiSoyadi").ToString();
            txtID.Text= gridView1.GetFocusedRowCellValue("kullaniciID").ToString();
            txtSifre.Text= gridView1.GetFocusedRowCellValue("sifre").ToString();
        }
    }
}
