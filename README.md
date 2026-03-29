# Restaurant Otomasyonu

C# WinForms (DevExpress bileşenleriyle) geliştirilmiş kapsamlı restoran yönetim uygulaması. Sipariş, masa, stok, kullanıcı ve raporlama modüllerini tek bir arayüzde sunar.

## Öne Çıkanlar
- Kullanıcı adı/şifre tabanlı giriş sistemi ve rol bazlı erişim yönetimi (`frmRolAtama`)
- Masa yönetimi ve rezervasyon takibi ayrı formlarda (`frmMasaYonetimi`, `frmMasaRezervasyon`)
- Sipariş geçmişi, günlük sipariş raporu ve aylık ciro raporlaması
- Stok modülü: düşük stok uyarısı (`frmDusukStok`) ve stok güncelleme (`frmStokGuncelle`)
- Veritabanı şeması ayrı bir `.sql` dosyasıyla (`DBrestaurant.sql`) versiyon kontrolünde tutulmuş

## Tech Stack
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![WinForms](https://img.shields.io/badge/WinForms-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![DevExpress](https://img.shields.io/badge/DevExpress-FF7200?style=flat-square&logo=devexpress&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)

## Proje Yapısı

```
restaurantOtomasyonu/
├── DBrestaurant.sql              # Veritabanı şeması
└── restaurantOtomasyonu/
    ├── frmGiris.cs               # Giriş ekranı
    ├── frmMasaYonetimi.cs        # Masa durumu yönetimi
    ├── frmMasaRezervasyon.cs     # Rezervasyon
    ├── frmSiparisler.cs          # Sipariş alma
    ├── frmSiparisDurumu.cs       # Sipariş durumu takibi
    ├── frmKategoriler.cs         # Ürün kategori yönetimi
    ├── frmUrun.cs                # Ürün yönetimi
    ├── frmStokGuncelle.cs        # Stok güncelleme
    ├── frmDusukStok.cs           # Düşük stok uyarısı
    ├── frmAylikCiro.cs           # Aylık ciro raporu
    ├── frmGunlukSiparisRaporu.cs # Günlük sipariş raporu
    ├── frmKullanicilar.cs        # Kullanıcı yönetimi
    ├── frmRolAtama.cs            # Rol ve yetki yönetimi
    └── baglanti.cs               # Merkezi DB bağlantısı
```

## Gereksinimler
- Visual Studio
- DevExpress WinForms bileşenleri
- SQL Server Express

## Kurulum

1. `DBrestaurant.sql` dosyasını SQL Server'da çalıştırarak veritabanını oluştur.
2. `baglanti.cs` içindeki bağlantı stringini kendi SQL Server örneğine göre güncelle.
3. `restaurantOtomasyonu.sln` dosyasını Visual Studio'da aç ve çalıştır.
