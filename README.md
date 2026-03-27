NaturalStore/
├── Domain/           
│   ├── Entities/
│   │   ├── BaseEntity.cs
│   │   ├── Company.cs
│   │   ├── Store.cs
│   │   ├── Employee.cs
│   │   ├── Client.cs
│   │   ├── Product.cs
│   │   ├── Category.cs
│   │   ├── Tag.cs
│   │   ├── ShoppingCart.cs
│   │   └── Sale.cs
│   ├── Enums/
│   │   └── Enums.cs         ← ContractType, EmployeeRole, PaymentMethod, SaleUnit
│   └── Interfaces/
│       └── IRepositories.cs ← Contratos de repositório
│
├── Infrastructure/          ← Implementações em memória dos repositórios
│   └── Repositories/
│       ├── InMemoryRepository.cs   (genérico abstrato)
│       └── ConcreteRepositories.cs (Employee, Client, Product, Sale, etc.)
│
├── Business/                ← Regras de negócio e serviços de aplicação
│   ├── Services/
│   │   ├── EmployeeService.cs
│   │   ├── ClientService.cs
│   │   ├── ProductService.cs
│   │   ├── CategoryService.cs
│   │   ├── TagService.cs
│   │   ├── StoreService.cs
│   │   ├── CartService.cs
│   │   └── SaleService.cs
│   └── AppContext.cs        ← Composição de dependências + dados iniciais (Seed)
│
├── ConsoleApp/              ← Interface de usuário (console)
│   ├── Helpers/
│   │   └── UI.cs            ← Utilitários de I/O com validação
│   ├── Menus/
│   │   ├── StoreMenu.cs
│   │   ├── EmployeeMenu.cs
│   │   ├── ClientMenu.cs
│   │   ├── CategoryTagMenus.cs
│   │   ├── ProductMenu.cs
│   │   └── SaleMenu.cs      ← PDV presencial + online + relatório gerencial
│   └── Program.cs           ← Ponto de entrada
│
├── Tests/                   ← Testes unitários XUnit
│   ├── EmployeeTests.cs
│   ├── ProductTests.cs
│   ├── CartAndSaleTests.cs
│   └── ClientTests.cs
│
└── NaturalStore.sln
