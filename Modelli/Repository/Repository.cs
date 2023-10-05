﻿using Microsoft.EntityFrameworkCore;
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
        //DbSet<Utente> dbSetUtenti = Context.ListaUtenti;
        //IQueryable<Utente> iQueryableUtenti = dbSetUtenti.Where(u => u.Username.Contains(ricerca) || u.Nome.Contains(ricerca) || u.Cognome.Contains(ricerca));
        //return iQueryableUtenti.ToList();

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
        Utente _ = GetUtenteById(utente.Id);
        Context.Remove(utente);
        Context.SaveChanges();
        return utente;
    }

    public Utente GetUtenteById(long id)
    {
        return Context.ListaUtenti.Where(u => u.Id == id).FirstOrDefault() ?? throw new Exception("utente non trovato");
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

    public List<Prodotto> ReadProdotto(string ricerca = "", bool hideOutOfStockItems = true)
    {
        DbSet<Prodotto> dbSetProdotti = Context.ListaProdotti;
        IQueryable<Prodotto> iQueryableProdotti = dbSetProdotti.Where(p => p.Nome.Contains(ricerca));
        if (hideOutOfStockItems)
            iQueryableProdotti = iQueryableProdotti.Where(p => p.Quantità > 0);
        return iQueryableProdotti.ToList();
    }

    public Prodotto? UpdateProdotto(Prodotto prodotto)
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

    public Prodotto? GetByIdProdotto(long id)
    {
        return Context.ListaProdotti.Where(p => p.Id == id).FirstOrDefault();

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

    public List<Acquisto> ReadAcquisto(string ricerca)
    {
        throw new NotImplementedException();
    }

    public Acquisto? UpdateAcquisto(Acquisto acquisto)
    {
        throw new NotImplementedException();
    }

    public Acquisto DeleteAcquisto(Acquisto acquisto)
    {
        Context.Remove(acquisto);
        Context.SaveChanges();
        return acquisto;
    }

    public Acquisto? GetByIdAcquisto(long id)
    {
        return Context.Find<Acquisto>(id);
    }

    #endregion
}
