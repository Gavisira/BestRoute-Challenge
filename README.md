# Best Route API

API desenvolvida em .NET Core, utilizando boas práticas como Repository Pattern, Dependency Injection e Entity Framework Core para gerenciar rotas de viagens e calcular o trajeto mais barato entre dois pontos.

## 📌 Configuração do Banco de Dados

A aplicação utiliza Entity Framework Core para persistência de dados. Para configurar o banco de dados, siga os seguintes passos:

### 1. Instalar pacote EF Core conforme o banco escolhido:

- Para SQL Server (exemplo usado atualmente):
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```


- Para SQLite:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 2. Configurar o banco no `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BestRouteDb;Trusted_Connection=True;"
}
```

Ou para SQLite:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=bestroutes.db"
}
```

### 3. Registrar no `Program.cs`:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

Troque `UseSqlServer` para outro provider como `UseSqlite`, se preferir SQLite.

### 2. Executar Migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## Front-end Angular (não implementado)

O frontend em Angular foi sugerido como um diferencial, porém não foi implementado nesta etapa, pois o foco inicial foi garantir uma API REST robusta, seguindo boas práticas de desenvolvimento, como uso do Repository Pattern e Dependency Injection. 

No entanto, a aplicação já disponibiliza endpoints REST documentados com Swagger, facilitando integração futura com qualquer front-end Angular ou outro framework.

---

Caso queira evoluir a aplicação adicionando um front-end Angular posteriormente, os endpoints existentes já permitem uma fácil integração.
