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

        DtoUtente CreateUtente(CreateUtente createUtente);

        List<DtoUtente> SearchUtente(ReadUtente readUtente);

        DtoUtente EditUtente(UpdateUtente updateUtente);

        DtoUtente DeleteUtente(DeleteUtente deleteUtente);

        DtoUtente GetUtenteById(long id);

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
