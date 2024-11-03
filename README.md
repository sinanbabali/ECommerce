## ��z�m Yap�s�

��z�m, sorumluluklar�n ayr�lmas�n� sa�lamak ve SOLID prensiplerine uymak i�in birka� projeye b�l�nm��t�r:

ECommerce.Api: Bu proje, API controller'lar�n� i�erir ve HTTP istek ve yan�tlar�n� y�netmekten sorumludur. Uygulaman�n giri� noktas� olarak hizmet eder.

ECommerce.Data: Bu proje, Entity Framework Core DbContext ve veritaban� modellerini i�erir. Veri eri�imi ve veritaban� etkile�imlerinden sorumludur.

ECommerce.Services: Bu proje, i� mant���n� ve servis katman�n� i�erir. Uygulaman�n temel i�levselli�ini uygulamaktan sorumludur.

ECommerce.Core: Bu proje, di�er projeler aras�nda payla��lan ortak modelleri, DTO'lar� ve yap�land�rmalar� i�erir.



Dependency Injection kullanarak ba��ml�l�klar� azaltt�m . Repository ve Service katmanlar�nda Repository Pattern desenini kulland�m.

ORM olarak Entity Framework kulland�m ve veritaban� modeli olu�turulurken seed data aktar�m� yapt�m.


## Log ve Hata Y�netimi (SeriLog)
Bu s�re�leri Ara Yaz�l�m (Middleware) kullanarak y�nettim.

HTTP istek ve yan�tlar�n� RequestLoggingMiddleware ile sa�lad�m
Uygulamada olu�abilecek hata y�netimini ExceptionHandlingMiddleware ile sa�lad�m. 



## Ekstra �zellikler

Validation i�lemleri i�in FluentValidation k�t�phanesini kulland�m.

Swagger UI �zerinde API dok�mantasyonu sa�lad�m.





## Kurulum Detaylar�

1- �nce Migration olu�turuyoruz 

Visual Studio kullan�yorsan:

Tools > NuGet Package Manager > Package Manager Console
A��lan konsola �u komutu yaz:

Add-Migration InitialCreate -Project ECommerce.Persistence

2- Migration'u Veritaban�na uyguluyoruz

dotnet ef database update --project ECommerce.Api

3- Art�k projeyi �al��t�rabiliriz.