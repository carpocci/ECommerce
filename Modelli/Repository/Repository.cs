using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Modelli.Repository;

public class Repository : IRepository
{
    protected ECommerceDbContext Context { get; }

    public Repository(IDbContextFactory<ECommerceDbContext> factory)
    {
        Context = factory.CreateDbContext();
    }

    #region Utente

    public Utente CreateUtente(Utente utente)
    {
        Context.Add(utente);
        Context.SaveChanges();
        return utente;
    }

    public List<Utente> SearchUtente(Utente utente)
    {
        IQueryable<Utente> iQueryableUtenti = Context.ListaUtenti.AsQueryable();
        if (utente.Username != null)
            iQueryableUtenti = iQueryableUtenti.Where(u => u.Username.Contains(utente.Username));
        if (utente.Nome != null)
            iQueryableUtenti = iQueryableUtenti.Where(u => u.Nome.Contains(utente.Nome));
        if (utente.Cognome != null)
            iQueryableUtenti = iQueryableUtenti.Where(u => u.Cognome.Contains(utente.Cognome));

        return iQueryableUtenti.ToList();
    }

    public Utente EditUtente(Utente utente)
    {
        Utente search = GetUtenteById(utente.Id);

        if (utente.Username != null)
            search.Username = utente.Username;
        if (utente.Nome != null)
            search.Nome = utente.Nome;
        if (utente.Cognome != null)
            search.Cognome = utente.Cognome;

        Context.Update(search);
        Context.SaveChanges();
        return search;
    }

    public Utente DeleteUtente(Utente utente)
    {
        Utente u = GetUtenteById(utente.Id);
        Context.Remove(u);
        Context.SaveChanges();
        return u;
    }

    public Utente GetUtenteById(long id)
    {
        return Context.ListaUtenti.Where(u => u.Id == id).FirstOrDefault() ?? throw new Exception("Utente non trovato");
    }

    #endregion

    #region Prodotto

    public Prodotto CreateProdotto(Prodotto prodotto)
    {
        if (prodotto.Quantità < 0)
        {
            throw new Exception("La quantità deve essere maggiore o uguale a 0");
        }
        Context.Add(prodotto);
        Context.SaveChanges();
        return prodotto;
    }

    public List<Prodotto> SearchProdotto(Prodotto prodotto, bool hideOutOfStockItems = true)
    {
        IQueryable<Prodotto> iQueryableUtenti = Context.ListaProdotti.AsQueryable();
        if (prodotto.Nome != null)
            iQueryableUtenti = iQueryableUtenti.Where(u => u.Nome.Contains(prodotto.Nome));

        return iQueryableUtenti.ToList();
    }

    public Prodotto EditProdotto(Prodotto prodotto)
    {
        if (prodotto.Quantità < 0)
        {
            throw new Exception("Quantità non valida");
        }
        Context.Update(prodotto);
        Context.SaveChanges();
        return prodotto;
    }

    public Prodotto DeleteProdotto(Prodotto prodotto)
    {
        Context.Remove(prodotto);
        Context.SaveChanges();
        return prodotto;
    }

    public Prodotto GetProdottoById(long id)
    {
        return Context.ListaProdotti.Where(p => p.Id == id).FirstOrDefault() ?? throw new Exception("Prodotto non trovato");

    }

    #endregion

    #region Acquisto

    public Acquisto? CreateAcquisto(Acquisto acquisto)
    {
        var prodotto = Context.ListaProdotti.FirstOrDefault(x => x.Id == acquisto.IdProdotto);
        if (prodotto == null)
        {
            return null;
        }

        if (prodotto.Quantità < acquisto.Quantità)
        {
            return null;
        }
        prodotto.Quantità -= acquisto.Quantità;

        var utente = Context.ListaUtenti.FirstOrDefault(x => x.Id == acquisto.IdUtente);
        if (utente == null)
        {
            return null;
        }


        Context.Add(acquisto);
        Context.SaveChanges();
        return acquisto;
    }

    public List<Acquisto> SearchAcquisto(Acquisto acquisto)
    {
        throw new NotImplementedException();
    }

    public Acquisto EditAcquisto(Acquisto acquisto)
    {
        throw new NotImplementedException();
    }

    public Acquisto DeleteAcquisto(Acquisto acquisto)
    {
        Context.Remove(acquisto);
        Context.SaveChanges();
        return acquisto;
    }

    public Acquisto GetAcquistoById(long id)
    {
        return Context
            .ListaAcquisti
            .Include(a => a.Utente)
            .Include(a => a.Prodotto)
            .Where(a => a.Id == id)
            .FirstOrDefault()
            ?? throw new Exception("Acquisto non trovato");
    }

    #endregion
}
