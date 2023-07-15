// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SampleEFCore_ProductsManagement.Data;
using SampleEFCore_ProductsManagement.Domain;
using SampleEFCore_ProductsManagement.ValueObjects;

Console.WriteLine("Hello, World!");

// Executar migrations via código
//var dbContext = new ApplicationContext();
//dbContext.Database.Migrate();

// Consultar migrations não executadas no banco de dados
//var dbContext = new ApplicationContext();
//var migrationsPending = dbContext.Database.GetPendingMigrations().Any();
//if (migrationsPending)
//    Console.WriteLine("There is migrations pending...");

// Diferentes formas de adicionar dados
//InsertData();

// Diferentes formas de adicionar dados em massa
//InsertManyData();

// Formas de realizar consulta de dados (consulta por sintaxe, consulta por metodo)
//QueryData();

// Carregar dados de entidades que possuem relacionamentos

LoadData();

static void InsertData()
{
    Product product = new()
    {
        Description = "Serviço teste",
        BarCode = "Bar",
        Value = 10m,
        ProductType = ProductType.Servico,
        Active = true
    };

    using var db = new ApplicationContext();
    //db.Products.Add(product); // Primeira forma (preciso ter uma propriedade DbSet no meu contexto)
    //db.Set<Product>().Add(product); // Segunda forma (não é necessário uma propriedade DbSet no meu Contexto)
    //db.Entry(product).State = EntityState.Added; // Terceira forma (forçar o rastreamento do produto)
    //db.Add(product); // Quarta forma (o ef core faz um discovery para verificar o objeto que será adicionado no banco) 

    var rowCount = db.SaveChanges(); // Necessário para persistir os dados na base de dados
    Console.WriteLine($"Total de registros afetados: {rowCount}");
}

static void InsertManyData()
{
    Product product = new()
    {
        Description = "Serviço teste",
        BarCode = "Bar",
        Value = 10m,
        ProductType = ProductType.Servico,
        Active = true
    };

    Client client = new()
    {
        Name = "Guilherme Ferrari",
        ZipCode = "11111000",
        City = "Capivari",
        State = "SP",
        Phone = "99000001111"
    };

    var clientList = new List<Client>()
    {
        new Client()
        {
            Name = "Cliente 1",
            ZipCode = "11111000",
            City = "Capivari",
            State = "SP",
            Phone = "99000001111"
        },
        new Client()
        {
            Name = "Cliente 2",
            ZipCode = "11111000",
            City = "Capivari",
            State = "SP",
            Phone = "99000001111"
        }
    };

    using var db = new ApplicationContext();
    db.AddRange(product, client); // Primeira forma (inserindo registros para diferentes entidades)
    db.Set<Client>().AddRange(clientList); // Segunda forma (inserindo uma lista de registros para uma mesma entidade)
    //db.Clients.AddRange(clientList); // Terceira forma (inserindo uma lista de registros para uma mesma entidade)

    var rowCount = db.SaveChanges(); // Necessário para persistir os dados na base de dados
    Console.WriteLine($"Total de registros afetados: {rowCount}");
}

static void QueryData()
{
    using var db = new ApplicationContext();

    //var sintaxQuery = (from c in db.Clients where c.Id > 0 select c).ToList(); // Consulta por sintaxe

    //var methodQuery = db.Clients.Where(c => c.Id > 0).ToList(); // Consulta por método rastreando em memória
    var methodQueryNoTracking = db.Clients.AsNoTracking().Where(c => c.Id < 5).ToList(); // Consulta por método sem rastrear na memória

    // Consultando o valor primeiramente em memória (Apenas o método Find() utiliza a memória) e caso não encontra, será buscado na base de dados (para isso não deve se usar o método AsNotracking() para não rastrear os objetos)
    foreach (var client in methodQueryNoTracking)
    {
        Console.WriteLine($"Consultando cliente: {client.Id}");
        db.Clients.Find(client.Id);
    }
}

static void LoadData()
{
    // Utilizamos o método Include() para fazer o carregamento adiantado e o ThenInclude() para carregar mais níveis
    using var db = new ApplicationContext();

    var orders = db.Orders
        .Include(i => i.OrderItems)
        .ThenInclude(p => p.Product)
        .ToList();
    
    Console.WriteLine(orders.Count);
}