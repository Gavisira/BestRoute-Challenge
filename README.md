# Best Route API

API desenvolvida em .NET Core, utilizando boas práticas como Repository Pattern, Dependency Injection e Entity Framework Core para gerenciar rotas de viagens e calcular o trajeto mais barato entre dois pontos.

## ✅ Recursos e Tecnologias Utilizados

- **.NET Core (Web API)**
- **Repository Pattern** (abstração do acesso ao banco de dados)
- **Dependency Injection** (para desacoplamento e manutenção)
- **Entity Framework Core** (persistência de dados)
- **SQLite ou SQL Server** (configurável)
- **Swagger** (documentação interativa da API)
- **Testes Unitários (XUnit e Moq)**
- **Estrutura de Grafos** (para o cálculo eficiente da melhor rota)
- 
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

### 4. Executar Migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---


## 📌 Estrutura do Projeto

- **Models:** Definição das entidades (ex: Route).
- **Repositories:** Interfaces e implementações para persistência de dados.
- **Services:** Lógica de negócio e cálculo da rota mais barata.
- **Controllers:** CRUD de rotas e endpoint para consulta da melhor rota.
- **Testes Unitários (XUnit/Moq):** Garantem a confiabilidade dos serviços e lógica do sistema.
- **Swagger:** Documentação interativa dos endpoints da API.

---

## 📌 Estrutura de Grafos

A aplicação utiliza a estrutura de grafos para representar os pontos de origem e destino das rotas, facilitando o cálculo eficiente da rota mais barata por meio do algoritmo de Dijkstra, que identifica o caminho com menor custo entre dois nós (pontos).

---

## ✅ Testes Unitários

A aplicação conta com testes unitários desenvolvidos utilizando o framework XUnit, com auxílio da biblioteca Moq para simular dependências. Os testes cobrem principalmente:

- Validação da lógica de cálculo da rota mais barata.
- Cenários de consulta com rotas existentes e não existentes.

Os testes são executáveis através do comando:
```bash
dotnet test
```

---

## 🎯 Front-end Angular (Não Implementado)

O frontend em Angular foi sugerido como um diferencial, porém não foi implementado nesta etapa, pois o foco inicial foi garantir uma API REST robusta, seguindo boas práticas de desenvolvimento, como uso do Repository Pattern e Dependency Injection. 

No entanto, a aplicação já disponibiliza endpoints REST documentados com Swagger, facilitando integração futura com qualquer front-end Angular ou outro framework.

---

Caso queira evoluir a aplicação adicionando um front-end Angular posteriormente, os endpoints existentes já permitem uma fácil integração.
