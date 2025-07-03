# ASP.NET Core Projesi

Bu proje, ASP.NET Core kullanılarak geliştirilmiş temel bir web uygulamasıdır.  
CRUD işlemleri, form validasyonu, ve AJAX ile dinamik veri yönetimi gibi özellikleri içerir.

## Özellikler

- MVC mimarisi  
- Entity Framework Core ile veri erişimi  
- Bootstrap 5 ile responsive tasarım  
- AJAX ile sayfa yenilemeden veri güncelleme  
- Model validation ve hata yönetimi

## Gereksinimler

- .NET 7 SDK veya üstü  
- Visual Studio 2022 / VS Code veya başka bir IDE  
- SQL Server (LocalDB veya tam sürüm)

## Kurulum

1. Projeyi klonla:

```bash
git clone https://github.com/kullaniciadi/projeadi.git
cd projeadi
Bağımlılıkları yükle:

bash
Kopyala
Düzenle
dotnet restore
Veritabanı bağlantısını appsettings.json dosyasında yapılandır:

json
Kopyala
Düzenle
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProjeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Veritabanını oluştur ve migrate et:

bash
Kopyala
Düzenle
dotnet ef database update
Çalıştırma
Projeyi şu komutla başlatabilirsin:

bash
Kopyala
Düzenle
dotnet run
Sonra tarayıcıda https://localhost:5001 adresini aç.

Katkıda Bulunma
Forkla

Yeni branch oluştur (git checkout -b yeni-ozellik)

Değişikliklerini commit et (git commit -m "Yeni özellik")

Pushla (git push origin yeni-ozellik)

Pull request gönder

Lisans
MIT Lisansı altında yayımlanmıştır.
