using Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.GraphQL.Types;

public class UtenteObjectType : ObjectType<Utente>
{
    protected override void Configure(IObjectTypeDescriptor<Utente> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Description("Dettaglio di un utente presente a database");

        descriptor.Field(u => u.Username).Description("Username dell'utente");
        descriptor.Field(u => u.Nome).Description("Nome dell'utente");
        descriptor.Field(u => u.Cognome).Description("Cognome dell'utente");
    }
}

public class ProdottoObjectType : ObjectType<Prodotto>
{
    protected override void Configure(IObjectTypeDescriptor<Prodotto> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Description("Dettaglio di un prodotto presente a database");

        descriptor.Field(u => u.Nome).Description("Nome del prodotto");
        descriptor.Field(u => u.Quantità).Description("Quantità del prodotto presente a magazzino");
    }
}

public class AcquistoObjectType : ObjectType<Acquisto>
{
    protected override void Configure(IObjectTypeDescriptor<Acquisto> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Description("Dettaglio di un utente presente a database");

        descriptor.Field(a => a.Id).Description("Id dell'acquisto");
        descriptor.Field(a => a.IdUtente).Description("Id dell'utente che ha effettuato l'acquisto");
        descriptor.Field(a => a.IdProdotto).Description("Id del prodotto acquistato");
        descriptor.Field(a => a.Quantità).Description("Quantità acquistata");
    }
    private class Resolver
    {
        public Utente? GetUtente([Parent] Acquisto acquisto, ECommerceDbContext context)
        {
            return context.ListaUtenti.Where(u => u.Id == acquisto.IdUtente).FirstOrDefault();
        }

        public Prodotto? GetProdotto([Parent] Acquisto acquisto, ECommerceDbContext context)
        {
            return context.ListaProdotti.Where(p => p.Id == acquisto.IdProdotto).FirstOrDefault();
        }
    }
}
