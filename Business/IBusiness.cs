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

        List<DtoProdotto> SearchProdotto(ReadProdotto readProdotto, bool hideOutOfStockItems = true);

        DtoProdotto? EditProdotto(UpdateProdotto updateProdotto);

        DtoProdotto DeleteProdotto(DeleteProdotto deleteProdotto);

        DtoProdotto? GetProdottoById(long id);

        #endregion

        #region Acquisto

        DtoAcquisto? CreateAcquisto(CreateAcquisto createAcquisto);

        List<DtoAcquisto> SearchAcquisto(ReadAcquisto readAcquisto);

        DtoAcquisto? EditAcquisto(UpdateAcquisto updateAcquisto);

        DtoAcquisto DeleteAcquisto(DeleteAcquisto deleteAcquisto);

        DtoAcquisto GetAcquistoById(long id);

        #endregion
    }
}
