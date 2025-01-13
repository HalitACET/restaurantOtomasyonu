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
    public partial class frmMasaRezervasyon : Form
    {
        public frmMasaRezervasyon()
        {
            InitializeComponent();
        }
        baglanti bgl = new baglanti();

        public void bilgiCek()
        {
            txtRezerveID.Text = gridView1.GetFocusedRowCellValue("RezerveID").ToString();
            txtMasaID.Text = gridView1.GetFocusedRowCellValue("masaID").ToString();
            txtRezerveZaman.Text = gridView1.GetFocusedRowCellValue("RezerveZamani").ToString();
            txtMasaAdi.Text = gridView1.GetFocusedRowCellValue("masaAdi").ToString();
            txtRezerveAdSoyad.Text = gridView1.GetFocusedRowCellValue("RezerveAdSoyad").ToString();
            if (gridView1.GetFocusedRowCellValue("Rezerve").ToString() == "True")
            {
                radioDolu.Checked = true;
                radioBos.Checked = false;
            }
            else if (gridView1.GetFocusedRowCellValue("Rezerve").ToString() == "False")
            {
                radioBos.Checked = true;
                radioDolu.Checked = false;
            }
        }
        public void Temizle()
        {
            txtRezerveID.Text = "";
            txtMasaID.Text = "";
            txtMasaAdi.Text = "";
            txtRezerveAdSoyad.Text = "";
            txtRezerveZaman.Text = "";
            radioBos.Checked = false;
            radioDolu.Checked = false;
        }
        public void masaListele()
        {
            string cmd = "select a.RezerveID, b.masaID, b.masaAdi, a.Rezerve, a.RezerveAdSoyad, a.RezerveZamani from tblRezerveMasalar as a right join tblMasalar as b on b.masaID=a.masaID";
            SqlDataAdapter da = new SqlDataAdapter(cmd, bgl.baglan());
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
        public void masaRezerveEt()
        {
            SqlCommand komut = new SqlCommand("insert into tblRezerveMasalar (Rezerve,masaID,RezerveAdSoyad,RezerveZamani) values (@p1,@p2,@p3,@p4)",bgl.baglan());
            if (radioDolu.Checked == true)
            {
                komut.Parameters.AddWithValue("@p1", true);
            }
            else if (radioBos.Checked == true)
            {
                komut.Parameters.AddWithValue("@p1", false);
            }
            komut.Parameters.AddWithValue("@p2",txtMasaID.Text);
            komut.Parameters.AddWithValue("@p3",txtRezerveAdSoyad.Text);
            komut.Parameters.AddWithValue("@p4", txtRezerveZaman.Text);
            komut.ExecuteNonQuery();
            bgl.baglan().Close();
            masaListele();
            Temizle();
        }
        public void masaRezerveGuncelle()
        {
            DialogResult onay = MessageBox.Show(txtMasaID.Text + " nolu masanın rezervesini güncellemek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("update tblRezerveMasalar set masaID=@p1, Rezerve=@p2, RezerveAdSoyad=@p3, RezerveZamani=@p4 where RezerveID=@p5", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", txtMasaID.Text);
                if (radioDolu.Checked == true)
                {
                    komut.Parameters.AddWithValue("@p2", true);
                }
                else if (radioBos.Checked == true)
                {
                    komut.Parameters.AddWithValue("@p2", false);
                }
                komut.Parameters.AddWithValue("@p3", txtRezerveAdSoyad.Text);
                komut.Parameters.AddWithValue("@p4", txtRezerveZaman.Text);
                komut.Parameters.AddWithValue("@p5", txtRezerveID.Text);
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                masaListele();
                Temizle();
            }
        }

        public void masaRezerveSil()
        {
            DialogResult onay = MessageBox.Show(txtMasaID.Text + " nolu masanın rezervesini silmek istediğinize emin misiniz?", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete from tblRezerveMasalar where RezerveID=@p1", bgl.baglan());
                komut.Parameters.AddWithValue("@p1", txtRezerveID.Text);
                komut.ExecuteNonQuery();
                bgl.baglan().Close();
                masaListele();
                Temizle();
            }
        }
        private void frmMasaDurumu_Load(object sender, EventArgs e)
        {
            
            masaListele();
            Temizle();
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
            masaRezerveEt();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            masaRezerveGuncelle();
        }

        private void btnRezerveSil_Click(object sender, EventArgs e)
        {
            masaRezerveSil();
        }
    }
}
