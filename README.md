# BankApp
## 📌 Proje Adı ve Kısa Açıklama
BankApp, ASP.NET Core 8 ile geliştirilmiş katmanlı mimariye sahip bir bankacılık uygulamasıdır. JWT tabanlı kimlik doğrulama ve isteğe bağlı OTP ile iki faktörlü giriş desteği sunar.

## ⚙️ Kullanılan Teknolojiler
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT & OTP (Two-Factor Authentication)
- Asp.Versioning
- Swagger (Swashbuckle)

## 🚀 Özellikler
- Hesap yönetimi: hesap oluşturma, bakiye görüntüleme ve kullanıcı işlemlerini listeleme
- Fatura işlemleri: fatura oluşturma ve ödeme
- Kimlik doğrulama: kullanıcı kaydı, oturum açma, JWT üretimi ve isteğe bağlı OTP
- Kullanıcı aktiviteleri: günlükleme ve ayar yönetimi
- Versiyonlanan API ve Swagger arayüzü

## 🛠 Kurulum ve Çalıştırma
### Gereksinimler
- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server erişimi ve uygun bağlantı dizesi (`appsettings.json`)

### Adımlar
```bash
# Depoyu klonla
git clone https://github.com/ornek/BankApp.git
cd BankApp

# Bağımlılıkları geri yükle
dotnet restore

# Veritabanı bağlantı dizesini `appsettings.json` içinde düzenle

# Varsa EF Core migration'larını uygula
dotnet ef database update

# Çözümü derle
dotnet build

# API katmanını çalıştır
dotnet run --project BankApp.WepApi
```
Uygulama çalıştığında `https://localhost:5001/swagger` adresinden API'yi inceleyebilirsiniz.

## 📂 Proje Yapısı
```
BankApp/
├─ BankApp.Data    # EF Core, varlıklar, depolar
├─ BankApp.Business  # İş kuralları ve servisler
└─ BankApp.WepApi  # RESTful API ve orta katmanlar
```
## 🔑 API Endpointleri / Kullanım Örnekleri
| HTTP | Endpoint | Açıklama |
|------|----------|---------|
| POST | `/api/v1/auth/register` | Yeni kullanıcı kaydı |
| POST | `/api/v1/auth/login` | Oturum açma |
| GET  | `/api/v1/accounts` | Kullanıcıya ait hesapları getirir |
| GET  | `/api/v1/accounts/{id}/balance` | Belirli hesabın bakiyesini döner |
| POST | `/api/v1/accounts/{id}/transfer` | Hesaplar arası transfer yapar |

Örnek:
```bash
curl -X POST https://localhost:5001/api/v1/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"kullanici@example.com","password":"Sifre123"}'
```


## 📖 Katkıda Bulunma
1. Bu projeyi forklayın.
2. Yeni bir özellik dalı oluşturun (`git checkout -b feature/ozellik`).
3. Değişikliklerinizi commit edin ve bir Pull Request açın.

## 📜 Lisans
Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.

## 👤 Yazar / İletişim
- Emre Yılmaz – [emreyilmazxy@gmail.com](mailto:emreyilmazxy@gmail.com)
