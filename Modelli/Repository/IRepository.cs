namespace Modelli.Repository
{
    public interface IRepository
    {
        #region Utente

        Utente CreateUtente(Utente utente);

        List<Utente> SearchUtente(Utente utente);

        Utente EditUtente(Utente utente);

        Utente DeleteUtente(Utente utente);

        Utente GetUtenteById(long id);

        #endregion

        #region Prodotto

        Prodotto CreateProdotto(Prodotto prodotto);

        List<Prodotto> SearchProdotto(Prodotto prodotto, bool hideOutOfStockItems = true);

        Prodotto EditProdotto(Prodotto prodotto);

        Prodotto DeleteProdotto(Prodotto prodotto);

        Prodotto GetProdottoById(long id);

        #endregion

        #region Acquisto

        Acquisto? CreateAcquisto(Acquisto acquisto);

        List<Acquisto> SearchAcquisto(Acquisto acquisto);

        Acquisto EditAcquisto(Acquisto acquisto);

        Acquisto DeleteAcquisto(Acquisto acquisto);

        Acquisto GetAcquistoById(long id);

        #endregion
    }
}
