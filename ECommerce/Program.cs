using Microsoft.EntityFrameworkCore;
using Modelli;
using Modelli.Repository;



// questo è un server Microsoft SQL Server installato in un container Docker
// docker run --rm -it --name mssql -e ACCEPT_EULA=Y -e MSSQL_PID=Developer -e MSSQL_SA_PASSWORD=p4ssw0rD -p 2433:1433 mcr.microsoft.com/mssql/server:2019-latest
string connectionstring = "Server=localhost,2433;Database=ecommerce;User Id=sa;Password=p4ssw0rD;Encrypt=False";

DbContextOptionsBuilder<ECommerceDbContext> optionsBuilder = new();
optionsBuilder.UseSqlServer(connectionstring);

ECommerceDbContext ctx1 = new(optionsBuilder.Options);
Repository repository = new(ctx1);

string[] opzioni =
{
    "inserisci utente",
    "cerca utente",
    "cerca prodotto",
    "inserisci prodotto",
    //"cerca acqisto",
    "inserisci acquisto",
    "esci",
};

while (true)
{
    Console.WriteLine();
    Console.WriteLine($"""Opzioni disponibili: {string.Join(", ", opzioni)}.""");
    Console.Write("Che cosa vuoi fare? ");
    string? scelta = Console.ReadLine();

    switch (scelta)
    {
        case "esci":
            return;

        case "cerca utente":
            Console.Write("Query: ");
            string query = Console.ReadLine() ?? "";
            foreach (var utente in repository.ReadUtente(query))
            {
                Console.WriteLine(utente);
            }
            break;

        case "inserisci utente":
            Console.Write("username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine() ?? "";

            Utente nuovo = new()
            {
                Username = username,
                Nome = nome,
                Cognome = cognome
            };

            Utente? test = repository.CreateUtente(nuovo);

            Console.WriteLine($"""Inserito utente "{test}".""");
            break;

        case "cerca prodotto":
            Console.Write("Query: ");
            string query_p = Console.ReadLine() ?? "";
            foreach (Prodotto prodottooo in repository.SearchProdotto(query_p))
            {
                Console.WriteLine(prodottooo);
            }
            break;

        case "inserisci prodotto":
            Console.Write("Nome: ");
            string nome_prodotto = Console.ReadLine() ?? "";
            Console.Write("Quantità: ");
            long quantità = long.Parse(Console.ReadLine() ?? "");

            Prodotto nuovo_prodotto = new()
            {
                Nome = nome_prodotto,
                Quantità = quantità,
            };

            Prodotto? test_prodotto = repository.CreateProdotto(nuovo_prodotto);

            Console.WriteLine($"""Inserito prodotto "{test_prodotto}".""");
            break;

        case "inserisci acquisto":
            Console.Write("Acquirente: ");
            long acquirente = long.Parse(Console.ReadLine() ?? "");
            Console.Write("Prodotto: ");
            long prodotto = long.Parse(Console.ReadLine() ?? "");
            Console.Write("Quantità: ");
            long quantità_acq = long.Parse(Console.ReadLine() ?? "");

            Acquisto nuovo_acq = new()
            {
                IdProdotto = prodotto,
                IdUtente = acquirente,
                Quantità = quantità_acq,
            };

            Acquisto? test_acq = repository.CreateAcquisto(nuovo_acq);

            if (test_acq == null)
            {
                Console.WriteLine("Valori non coerenti");
            }
            else
            {
                Console.WriteLine($"""Inserito acquisto "{test_acq}".""");
            }

            break;

        default:
            break;

    }
}