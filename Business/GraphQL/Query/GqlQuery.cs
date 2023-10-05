using Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.GraphQL.Query;

public class GqlQuery
{
    [UseDbContext(typeof(ECommerceDbContext))]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Elenco degli utenti")]
    public IQueryable<Utente> GetUtente(ECommerceDbContext context) => context.ListaUtenti;

    [UseDbContext(typeof(ECommerceDbContext))]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Elenco dei prodotti")]
    public IQueryable<Prodotto> GetProdotto(ECommerceDbContext context) => context.ListaProdotti;

    [UseDbContext(typeof(ECommerceDbContext))]
    [GraphQLDescription("Elenco degli acquisti effettuati")]
    public IQueryable<Acquisto> GetAcquisto(ECommerceDbContext context) => context.ListaAcquisti;
}
