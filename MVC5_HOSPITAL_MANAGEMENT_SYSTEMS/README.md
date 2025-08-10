
# ASP.NET MVC Hastane Yönetim Sistemi

Bu proje, hastane operasyonlarını yönetmek için geliştirilmiş kapsamlı bir web uygulamasıdır. ASP.NET MVC 5 kullanılarak oluşturulmuştur ve yönetici, doktor, personel ve hastalar için farklı rollere dayalı işlevler sunar.

## ✨ Temel Özellikler

*   **Rol Tabanlı Yetkilendirme:**
    *   **Yönetici Paneli:** Sistemin genel verilerini izleme, doktor, personel ve hasta yönetimi.
    *   **Doktor Paneli:** Hastaları listeleme, muayene sonuçlarını görüntüleme ve reçete yazma.
    *   **Personel Paneli:** Laboratuvar sonuçlarını (kan, idrar, radyoloji) sisteme girme.
    *   **Hasta Erişimi:** Randevu oluşturma, görüntüleme, düzenleme ve silme.

*   **Yönetim Modülleri (CRUD İşlemleri):**
    *   Doktor Yönetimi
    *   Hasta Yönetimi
    *   Personel Yönetimi
    *   İlaç Yönetimi
    *   Yorum ve İletişim Mesajları Yönetimi

*   **Tıbbi İşlemler:**
    *   Online Randevu Sistemi
    *   Muayene Sonuçları Görüntüleme (Kan, İdrar, Radyoloji)
    *   Dinamik Reçete Oluşturma ve Görüntüleme

*   **Kullanıcı Arayüzü ve Deneyimi:**
    *   Genel hastane bilgi sayfaları (Tarihçe, Değerlerimiz, Diyabet Okulu vb.).
    *   Sayfalandırma (PagedList) ile kolay veri gezintisi.
    *   Arama ve filtreleme özellikleri.
    *   Yönetici paneli için dashboard ve grafikler.

## 🛠️ Kullanılan Teknolojiler

*   **Backend:** C#, ASP.NET MVC 5
*   **Veritabanı:** Entity Framework (Code-First yaklaşımı)
*   **Frontend:** HTML, CSS, JavaScript (Razor View Engine ile)
*   **Kütüphaneler:** PagedList.Mvc (Sayfalandırma için)
*   **Kimlik Doğrulama:** ASP.NET Forms Authentication

## 📂 Proje Yapısı

Proje, standart ASP.NET MVC mimarisine uygun olarak yapılandırılmıştır:

```
/
├── Controllers/        # Uygulama mantığını ve kullanıcı isteklerini yönetir
│   ├── AdminController.cs
│   ├── AnasayfaController.cs
│   ├── DoktorController.cs
│   ├── HastaController.cs
│   ├── LoginController.cs
│   ├── MedicineController.cs
│   ├── MuayeneController.cs
│   ├── PersonelController.cs
│   ├── PersonelIslemController.cs
│   └── RandevuController.cs
│
├── Models/             # Veritabanı tablolarını ve uygulama varlıklarını temsil eder
│   ├── DatabaseContext.cs
│   ├── Admin.cs, Doktor.cs, Hasta.cs, Personel.cs, ...
│   └── VmModels/       # Birden fazla modeli tek bir view'de kullanmak için ViewModel'lar
│       └── HareketVM.cs, KanSonucVM.cs, ...
│
└── Views/              # Kullanıcı arayüzünü (UI) oluşturan Razor dosyaları
    ├── Admin/
    ├── Anasayfa/
    ├── Doktor/
    ├── Hasta/
    ├── Login/
    ├── ...
    └── Shared/         # Paylaşılan layout ve partial view'lar
        └── _Layout.cshtml, AdminLayout.cshtml
```

### Modeller (Models)

Veritabanı tablolarını temsil eden ana varlık sınıfları:

*   **`Admin`, `Doktor`, `Personel`, `Hasta`:** Sistemin kullanıcı rollerini ve bilgilerini tutar.
*   **`Medicine`:** İlaç bilgilerini yönetir.
*   **`Kan`, `Idrar`, `Radyoloji`:** Laboratuvar tahlil sonuçlarını depolar.
*   **`Recete`:** Doktorların oluşturduğu reçeteleri saklar.
*   **`Message`, `Yorum`:** Kullanıcılardan gelen iletişim mesajlarını ve yorumları yönetir.
*   **`DatabaseContext.cs`:** Entity Framework aracılığıyla veritabanı bağlantısını ve `DbSet`'leri yönetir.

### ViewModel'lar (VmModels)

View'lere karmaşık veya birden çok modeli tek bir nesne olarak göndermek için kullanılır:

*   **`HareketVM`:** Yönetici paneli dashboard'ı için birden çok listeyi (hasta, doktor, personel vb.) bir araya getirir.
*   **`KanSonucVM`, `IdrarVM`, `RadyolojiVM`:** Personelin tahlil sonucu girerken hasta bilgileriyle birlikte ilgili sonucu taşımasını sağlar.
*   **`ReceteVM`:** Reçete oluşturma ekranında hasta bilgilerini ve yeni reçete nesnesini birleştirir.

### Denetleyiciler (Controllers)

*   **`LoginController`:** Yönetici, doktor ve personel için giriş (authentication) işlemlerini yönetir. `FormsAuthentication.SetAuthCookie` ile kullanıcı oturumlarını başlatır.
*   **`AdminController`:** Yönetici paneli işlevlerini barındırır. Dashboard verilerini hazırlar, CRUD işlemlerini (Yorum, İletişim) yönetir ve sistemdeki tüm ana verileri listeler.
*   **`AnasayfaController`:** Ziyaretçilere açık olan genel sayfaları (Hakkımızda, Doktorlarımız, İletişim vb.) sunar.
*   **`RandevuController`:** Hastaların poliklinik ve doktora göre randevu almasını, görüntülemesini ve yönetmesini sağlar.
*   **`DoktorController`, `HastaController`, `PersonelController`, `MedicineController`:** İlgili modüller için temel CRUD (Ekle, Sil, Güncelle, Listele) işlemlerini gerçekleştirir.
*   **`MuayeneController`:** Doktorların, hastalarının tahlil sonuçlarını görüntülemesine ve onlara reçete yazmasına olanak tanır.
*   **`PersonelIslemController`:** Laboratuvar personelinin hasta tahlil sonuçlarını sisteme girmesini sağlar.

### Görünümler (Views)

Her `Controller` için ayrı klasörlerde bulunan `.cshtml` dosyalarıdır. Kullanıcı arayüzünü oluşturmak için Razor sözdizimini kullanır.

*   **`Shared/_Layout.cshtml`:** Sitenin genel şablonunu içerir.
*   **`Shared/AdminLayout.cshtml`:** Yönetici paneli için özel bir şablon sunar.
*   **Sayfalandırma:** `PagedList.Mvc` kullanılarak listeleme sayfalarında kullanıcı dostu bir gezinme sağlanmıştır.
*   **Formlar:** `Html.BeginForm()` gibi HTML Helper'lar kullanılarak güçlü tipli (strongly-typed) formlar oluşturulmuştur.

## 🚀 Projeyi Çalıştırma

Bu projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

1.  **Projeyi Klonlayın veya İndirin:**
    Projeyi bilgisayarınıza indirin.

2.  **NuGet Paketlerini Geri Yükleyin:**
    Visual Studio'da projeyi açın ve "Solution Explorer" penceresinde çözüme sağ tıklayarak "Restore NuGet Packages" seçeneğini seçin.

3.  **Veritabanı Bağlantısını Yapılandırın:**
    `Web.config` dosyasındaki `connectionStrings` bölümünü kendi SQL Server yapılandırmanıza göre güncelleyin.

    ```xml
    <connectionStrings>
      <add name="DatabaseContext" connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=HospitalDB;Integrated Security=True" providerName="System.Data.SqlClient" />
    </connectionStrings>
    ```

4.  **Veritabanını Oluşturun (Update-Database):**
    "Package Manager Console"u açın (`View > Other Windows > Package Manager Console`) ve aşağıdaki komutu çalıştırarak veritabanını oluşturun ve başlangıç verilerini (varsa) ekleyin.

    ```powershell
    Update-Database
    ```

5.  **Projeyi Başlatın:**
    Visual Studio'da `IIS Express` (veya tercih ettiğiniz bir tarayıcı) ile projeyi başlatmak için `F5` tuşuna basın.

---
