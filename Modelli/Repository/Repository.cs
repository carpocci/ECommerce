using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modelli.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelli.Repository;

public class Repository : IRepository
{
    protected ECommerceDbContext Context { get; }
    protected IMapper Mapper { get; }


    public Repository(IDbContextFactory<ECommerceDbContext> factory)
    {
        Context = factory.CreateDbContext();

        Mapper = new Mapper(
            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Utente, DtoUtente>();
                cfg.CreateMap<DtoUtente, Utente>();

                cfg.CreateMap<CreateUtente, Utente>();
                cfg.CreateMap<ReadUtente, Utente>();
                cfg.CreateMap<UpdateUtente, Utente>();
                cfg.CreateMap<DeleteUtente, Utente>();
            }));
    }

    #region Utente

    public DtoUtente CreateUtente(CreateUtente createUtente)
    {
        Utente utente = Mapper.Map<Utente>(createUtente);
        Context.Add(utente);
        Context.SaveChanges();
        return Mapper.Map<DtoUtente>(utente);
    }

    public List<DtoUtente> CercaUtente(ReadUtente readUtente)
    {
        //DbSet<Utente> dbSetUtenti = Context.ListaUtenti;
        //IQueryable<Utente> iQueryableUtenti = dbSetUtenti.Where(u => u.Username.Contains(ricerca) || u.Nome.Contains(ricerca) || u.Cognome.Contains(ricerca));
        //return iQueryableUtenti.ToList();

        IQueryable<Utente> iQueryableUtenti = Context.ListaUtenti.AsQueryable();
        if (readUtente.Username != null)
            iQueryableUtenti = iQueryableUtenti.Where(u => u.Username.Contains(readUtente.Username));
        if (readUtente.Nome != null)
            iQueryableUtenti = iQueryableUtenti.Where(u => u.Nome.Contains(readUtente.Nome));
        if (readUtente.Cognome != null)
            iQueryableUtenti = iQueryableUtenti.Where(u => u.Cognome.Contains(readUtente.Cognome));

        return iQueryableUtenti.Select(u => Mapper.Map<DtoUtente>(u)).ToList();

    }

    public DtoUtente UpdateUtente(UpdateUtente updateUtente)
    {
        Utente utente = Context.ListaUtenti.Where(u => u.Id == updateUtente.Id).First();

        if ( updateUtente.Username != null)
            utente.Username = updateUtente.Username;
        if (updateUtente.Nome != null)
            utente.Nome = updateUtente.Nome;
        if (updateUtente.Cognome != null)
            utente.Cognome = updateUtente.Cognome;

        Context.Update(utente);
        Context.SaveChanges(true);
        return Mapper.Map<DtoUtente>(utente);
    }

    public Utente DeleteUtente(Utente utente)
    {
        Context.Remove(utente);
        Context.SaveChanges();
        return utente;
    }

    public Utente? GetUtenteById(long id)
    {
        return Context.Find<Utente>(id);

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
