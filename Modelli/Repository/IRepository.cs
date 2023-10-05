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
