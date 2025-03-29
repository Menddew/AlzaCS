# AlzaCS – CASE STUDY

CASE STUDY REST API vytvořené v .NET 9, s podporou verzování, stránkování, asynchronní fronty a unit testy. Projekt demonstruje čistý, škálovatelný a testovatelný backend podle principů REST, SOLID a moderní architektury.

---

## 🚀 Funkce

- ✅ RESTful API pro práci s produkty
- ✅ Verze 1 (CRUD + PATCH sklad)
- ✅ Verze 2 (GET s pagination + async PATCH přes frontu)
- ✅ Swagger UI dokumentace
- ✅ SQLite + EF Core
- ✅ Unit testy s xUnit + InMemory databází
- ✅ BackgroundService pro zpracování fronty
- ✅ Čistá architektura a oddělení vrstev

---

## 🛠️ Technologie

- [.NET 9](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Entity Framework Core (SQLite)
- Swagger (Swashbuckle)
- xUnit
- BackgroundService + Channel (in-memory queue)

---

## 🗃️ Entity: Product

```json
{
  "id": 1,
  "name": "Example Product",
  "imageUrl": "https://example.com/image.jpg",
  "price": 99.99,
  "description": "Product description",
  "quantity": 50
}
```

---

## 📂 Struktura

- `/Controllers` – REST API v1 a v2
- `/Models` – entity a request DTOs
- `/Data` – `AppDbContext` a EF konfigurace
- `/Services` – Background queue
- `/Tests` – unit testy s xUnit

---

## 📦 Instalace a spuštění

### 🔧 Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/)
- IDE: Visual Studio 2022+ nebo VS Code

### 🏁 Spuštění projektu

```bash
dotnet build
dotnet ef database update
dotnet run
```

Otevři Swagger:
```
https://localhost:xxxx/swagger
```

---

## 🔍 API Endpoints

### ✅ Verze 1 – `/api/v1/products`

| Metoda | Popis                        |
|--------|------------------------------|
| GET    | Získat všechny produkty      |
| GET /{id} | Získat produkt podle ID  |
| POST   | Vytvořit nový produkt (name + imageUrl) |
| PATCH /{id}/stock | Aktualizace skladu |

---

### 🔁 Verze 2 – `/api/v2/products`

| Metoda | Popis                                     |
|--------|--------------------------------------------|
| GET    | Seznam produktů s pagination (`?page=1&pageSize=10`) |
| POST /{id}/stock | Zařadí požadavek na změnu skladu do fronty |

---

## 🧪 Spuštění testů

```bash
dotnet test
```

Testy používají EF Core InMemory databázi a kontrolují správnost endpointů v `ProductsController`.

---

## 💡 Možné rozšíření

- RabbitMQ/Kafka místo in-memory fronty
- Caching (např. Redis)
- Autentizace (JWT)
- CI/CD pipeline (GitHub Actions)
- Frontend klient (Blazor nebo React)

---

Projekt vytvořen jako case study podle zadaných požadavků.  
