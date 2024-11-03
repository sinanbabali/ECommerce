## Çözüm Yapýsý

Çözüm, sorumluluklarýn ayrýlmasýný saðlamak ve SOLID prensiplerine uymak için birkaç projeye bölünmüþtür:

ECommerce.Api: Bu proje, API controller'larýný içerir ve HTTP istek ve yanýtlarýný yönetmekten sorumludur. Uygulamanýn giriþ noktasý olarak hizmet eder.

ECommerce.Data: Bu proje, Entity Framework Core DbContext ve veritabaný modellerini içerir. Veri eriþimi ve veritabaný etkileþimlerinden sorumludur.

ECommerce.Services: Bu proje, iþ mantýðýný ve servis katmanýný içerir. Uygulamanýn temel iþlevselliðini uygulamaktan sorumludur.

ECommerce.Core: Bu proje, diðer projeler arasýnda paylaþýlan ortak modelleri, DTO'larý ve yapýlandýrmalarý içerir.



Dependency Injection kullanarak baðýmlýlýklarý azalttým . Repository ve Service katmanlarýnda Repository Pattern desenini kullandým.

ORM olarak Entity Framework kullandým ve veritabaný modeli oluþturulurken seed data aktarýmý yaptým.


## Log ve Hata Yönetimi (SeriLog)
Bu süreçleri Ara Yazýlým (Middleware) kullanarak yönettim.

HTTP istek ve yanýtlarýný RequestLoggingMiddleware ile saðladým
Uygulamada oluþabilecek hata yönetimini ExceptionHandlingMiddleware ile saðladým. 



## Ekstra Özellikler

Validation iþlemleri için FluentValidation kütüphanesini kullandým.

Swagger UI üzerinde API dokümantasyonu saðladým.





## Kurulum Detaylarý

1- Önce Migration oluþturuyoruz 

Visual Studio kullanýyorsan:

Tools > NuGet Package Manager > Package Manager Console
Açýlan konsola þu komutu yaz:

Add-Migration InitialCreate -Project ECommerce.Persistence

2- Migration'u Veritabanýna uyguluyoruz

dotnet ef database update --project ECommerce.Api

3- Artýk projeyi çalýþtýrabiliriz.