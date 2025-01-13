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
    public partial class frmRolAtama : Form
    {
        public frmRolAtama()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();
        public void bilgiCek()
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("kullaniciID").ToString();
            txtAdSoyad.Text = gridView1.GetFocusedRowCellValue("kullaniciAdiSoyadi").ToString();
            cmbRolAta.SelectedItem = gridView1.GetFocusedRowCellValue("rol").ToString();
        }
        public void Listele()
        {
            string cmd = "Select * from TblKullanicilar";
            SqlDataAdapter da = new SqlDataAdapter(cmd, bgl.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
        public void Temizle()
        {
            txtID.Text = "";
            txtAdSoyad.Text = "";
            cmbRolAta.Text = "";
        }
        public void rolAta()
        {
            DialogResult onay = MessageBox.Show(txtID.Text + " nolu kullanıcıya " + cmbRolAta.SelectedItem + " rolünü vermek istediğinize emin misiniz?","Onay Kutusu",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("update tblKullanicilar set rol=@p1 where kullaniciID=@p2", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", cmbRolAta.SelectedItem);
                komut.Parameters.AddWithValue("@p2", txtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                Listele();
                Temizle();
            }
        }
        private void btnRolAta_Click(object sender, EventArgs e)
        {
            rolAta();
        }

        private void frmRolAtama_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            bilgiCek();
        }
    }
}
