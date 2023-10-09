using Modelli;

namespace Business.GraphQL.Query;

public class GqlQuery
{
    //Paging
    //Projection
    //Filtering
    //Sorting

    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Elenco degli utenti")]
    public IQueryable<Utente> GetUtente(ECommerceDbContext context) => context.ListaUtenti;

    [UseOffsetPaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Elenco dei prodotti")]
    public IQueryable<Prodotto> GetProdotto(ECommerceDbContext context) => context.ListaProdotti;

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Elenco degli acquisti effettuati")]
    public IQueryable<Acquisto> GetAcquisto(ECommerceDbContext context) => context.ListaAcquisti;
}
