using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace restaurantOtomasyonu
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUrun frmUrun = new frmUrun();
            frmUrun.MdiParent = this;
            frmUrun.Show();
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmStokGuncelle frmStokGuncelle = new frmStokGuncelle();
            frmStokGuncelle.Show();
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            
        }

        private void kategoriYonetimi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKategoriler frmKategoriler = new frmKategoriler();
            frmKategoriler.Show();
        }

        private void kullaniciYonetimi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKullanicilar frmKullanicilar = new frmKullanicilar();
            frmKullanicilar.MdiParent = this;
            frmKullanicilar.Show();
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRolAtama frmRolAtama = new frmRolAtama();
            frmRolAtama.Show();
        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmParolaSifirla frmParolaSifirla = new frmParolaSifirla();
            frmParolaSifirla.Show();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTumMasalar frmTumMasalar = new frmTumMasalar();
            frmTumMasalar.MdiParent = this;
            frmTumMasalar.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMasaYonetimi frmMasaYonetimi = new frmMasaYonetimi();
            frmMasaYonetimi.MdiParent = this;
            frmMasaYonetimi.Show();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMasaRezervasyon frmMasaRezervasyon = new frmMasaRezervasyon();
            frmMasaRezervasyon.MdiParent = this;
            frmMasaRezervasyon.Show();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSiparisler frmSiparisler = new frmSiparisler();
            frmSiparisler.MdiParent = this;
            frmSiparisler.Show();
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSiparisDurumu frmSiparisDurumu = new frmSiparisDurumu();
            frmSiparisDurumu.MdiParent = this;
            frmSiparisDurumu.Show();
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSiparisGecmisi frmSiparisGecmisi = new frmSiparisGecmisi();
            frmSiparisGecmisi.MdiParent = this;
            frmSiparisGecmisi.Show();
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSiparisRapor frmGunlukSiparisRapor = new frmSiparisRapor();
            frmGunlukSiparisRapor.MdiParent = this;
            frmGunlukSiparisRapor.Show();
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDusukStok frmDusukStok = new frmDusukStok();
            frmDusukStok.MdiParent = this;
            frmDusukStok.Show();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSiparisRapor frmSiparisRapor = new frmSiparisRapor();
            frmSiparisRapor.MdiParent = this;
            frmSiparisRapor.Show();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUrunSatisRaporu frmUrunSatisRaporu = new frmUrunSatisRaporu();
            frmUrunSatisRaporu.MdiParent = this;
            frmUrunSatisRaporu.Show();
        }

        private void barButtonItem12_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmUrunRapor frmUrunRapor = new frmUrunRapor();
            frmUrunRapor.MdiParent = this;
            frmUrunRapor.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSiparisler frmSiparisler = new frmSiparisler();
            frmSiparisler.MdiParent = this;
            frmSiparisler.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTumMasalar frmTumMasalar = new frmTumMasalar();
            frmTumMasalar.MdiParent = this;
            frmTumMasalar.Show();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDusukStok frmDusukStok = new frmDusukStok();
            frmDusukStok.MdiParent = this;
            frmDusukStok.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmGunlukSiparisRaporu frmGunlukSiparisRaporu = new frmGunlukSiparisRaporu();
            frmGunlukSiparisRaporu.MdiParent = this;
            frmGunlukSiparisRaporu.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSiparisDurumu frmSiparisDurumu = new frmSiparisDurumu();
            frmSiparisDurumu.MdiParent = this;
            frmSiparisDurumu.Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAylikCiro frmAylikCiro = new frmAylikCiro();
            frmAylikCiro.MdiParent = this;
            frmAylikCiro.Show();
        }
    }
}