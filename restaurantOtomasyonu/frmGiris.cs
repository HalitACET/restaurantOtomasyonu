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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RO4FTV6\SQLEXPRESS;Initial Catalog=restaurantOtomasyonu;Integrated Security=True");

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi, sifre;

            kullaniciAdi = textEdit1.Text;
            sifre = textEdit2.Text;

            baglanti.Open();

            SqlCommand komut = new SqlCommand("SELECT kullaniciAdiSoyadi, sifre FROM tblKullanicilar WHERE kullaniciAdiSoyadi = @kullaniciAdiSoyadi AND sifre = @sifre", baglanti);

            komut.Parameters.AddWithValue("@kullaniciAdiSoyadi", kullaniciAdi);
            komut.Parameters.AddWithValue("@sifre", sifre);

            object result = komut.ExecuteScalar();
            if (result != null)
            {
                
                MessageBox.Show($"Hoş geldiniz, {kullaniciAdi}!", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Giriş başarılı, ana formu açın
                RibbonForm1 mainForm = new RibbonForm1();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
