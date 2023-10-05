using Business.Dto;

namespace Business
{
    public interface IBusiness
    {
        #region Utente

        DtoUtente CreateUtente(CreateUtente createUtente);

        List<DtoUtente> SearchUtente(ReadUtente readUtente);

        DtoUtente EditUtente(UpdateUtente updateUtente);

        DtoUtente DeleteUtente(DeleteUtente deleteUtente);

        DtoUtente GetUtenteById(long id);

        #endregion

        #region Prodotto

        DtoProdotto CreateProdotto(CreateProdotto createProdotto);

        List<DtoProdotto> ReadProdotto(ReadProdotto readProdotto, bool hideOutOfStockItems = true);

        DtoProdotto? UpdateProdotto(UpdateProdotto updateProdotto);

        DtoProdotto DeleteProdotto(DeleteProdotto deleteProdotto);

        DtoProdotto? GetByIdProdotto(long id);

        #endregion

        #region Acquisto

        DtoAcquisto? CreateAcquisto(CreateAcquisto createAcquisto);

        List<DtoAcquisto> ReadAcquisto(ReadAcquisto readAcquisto);

        DtoAcquisto? UpdateAcquisto(UpdateAcquisto updateAcquisto);

        DtoAcquisto DeleteAcquisto(DeleteAcquisto deleteAcquisto);

        DtoAcquisto? GetByIdAcquisto(long id);

        #endregion
    }
}
