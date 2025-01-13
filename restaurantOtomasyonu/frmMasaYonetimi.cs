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
    public partial class frmMasaYonetimi : Form
    {
        public frmMasaYonetimi()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();

        public void bilgiCek()
        {
            txtMasaID.Text = gridView1.GetFocusedRowCellValue("masaID").ToString();
            txtMasaAdi.Text = gridView1.GetFocusedRowCellValue("masaAdi").ToString();
            if (gridView1.GetFocusedRowCellValue("Durum").ToString() == "True")
            {
                radioDolu.Checked = true;
                radioBos.Checked = false;
            }
            else if (gridView1.GetFocusedRowCellValue("Durum").ToString() == "False")
            {
                radioBos.Checked = true;
                radioDolu.Checked = false;
            }
        }
        public void Temizle()
        {
            txtMasaID.Text = "";
            txtMasaAdi.Text = "";
            radioBos.Checked = false;
            radioDolu.Checked = false;
        }
        public void masaListele()
        {
            string cmd = "select * from tblMasalar";
            SqlDataAdapter da = new SqlDataAdapter(cmd, bgl.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
        public void masaEkle()
        {
            SqlCommand komut = new SqlCommand("insert into tblMasalar (masaAdi,Durum) values (@p1,@p2)",bgl.baglan());
            komut.Parameters.AddWithValue("@p1", txtMasaAdi.Text);
            if (radioBos.Checked == true)
            {
                komut.Parameters.AddWithValue("@p2", 0);
            }
            else if (radioDolu.Checked == true)
            {
                komut.Parameters.AddWithValue("@p2",1);
            }
            komut.ExecuteNonQuery();
            bgl.baglan().Close();
            masaListele();
            Temizle();
        }
        public void masaGuncelle()
        {
            DialogResult onay = MessageBox.Show(txtMasaID.Text + " nolu masayı güncellemek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("update tblMasalar set masaAdi=@p1, Durum=@p2 where MasaID=@p3", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", txtMasaAdi.Text);
                if (radioBos.Checked == true)
                {
                    komut.Parameters.AddWithValue("@p2", 0);
                }
                else if (radioDolu.Checked == true)
                {
                    komut.Parameters.AddWithValue("@p2", 1);
                }
                komut.Parameters.AddWithValue("@p3", txtMasaID.Text);
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                masaListele();
                Temizle();
            }
        }
        public void masaSil()
        {
            DialogResult onay = MessageBox.Show(txtMasaID.Text + " nolu masayı silmek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from tblMasalar where masaID=@p1", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", txtMasaID.Text);
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                masaListele();
                Temizle();
            }
        }
        private void frmMasaYonetimi_Load(object sender, EventArgs e)
        {
            masaListele();
            Temizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            masaEkle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            masaGuncelle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            masaSil();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            bilgiCek();
        }
    }
}
