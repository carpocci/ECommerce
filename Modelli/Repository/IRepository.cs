using Modelli.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelli.Repository
{
    public interface IRepository
    {
        #region Utente

        //Utente CreateUtente(Utente utente);
        DtoUtente CreateUtente(CreateUtente createUtente);

        //List<Utente> ReadUtente(String ricerca);
        List<DtoUtente> CercaUtente(ReadUtente readUtente);

        DtoUtente UpdateUtente(UpdateUtente updateUtente);

        Utente DeleteUtente(Utente utente);
        //Utente DeleteUtente(DeleteUtente deleteUtente);

        Utente GetUtenteById(long id);
        //Utente GetByIdUtente(long id);

        #endregion

        #region Prodotto

        Prodotto CreateProdotto(Prodotto prodotto);

        List<Prodotto> ReadProdotto(string ricerca, bool hideOutOfStockItems = true);

        Prodotto? UpdateProdotto(Prodotto prodotto);

        Prodotto DeleteProdotto(Prodotto prodotto);

        Prodotto? GetByIdProdotto(long id);

        #endregion

        #region Acquisto

        Acquisto? CreateAcquisto(Acquisto acquisto);

        List<Acquisto> ReadAcquisto(string ricerca);

        Acquisto? UpdateAcquisto(Acquisto acquisto);

        Acquisto DeleteAcquisto(Acquisto acquisto);

        Acquisto? GetByIdAcquisto(long id);

        #endregion
    }
}
