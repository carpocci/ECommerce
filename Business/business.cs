using AutoMapper;
using Business.Dto;
using Modelli;
using Modelli.Repository;

namespace Business
{
    public class Business : IBusiness
    {
        protected IMapper Mapper { get; }
        protected IRepository Repository { get; }

        public Business(IRepository repository)
        {
            Mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Utente, DtoUtente>();
                    cfg.CreateMap<DtoUtente, Utente>();

                    cfg.CreateMap<CreateUtente, Utente>();
                    cfg.CreateMap<ReadUtente, Utente>();
                    cfg.CreateMap<UpdateUtente, Utente>();
                    cfg.CreateMap<DeleteUtente, Utente>();


                    cfg.CreateMap<Prodotto, DtoProdotto>();
                    cfg.CreateMap<DtoProdotto, Prodotto>();

                    cfg.CreateMap<CreateProdotto, Prodotto>();
                    cfg.CreateMap<ReadProdotto, Prodotto>();
                    cfg.CreateMap<UpdateProdotto, Prodotto>();
                    cfg.CreateMap<DeleteProdotto, Prodotto>();

                    cfg.CreateMap<Utente, DtoUtente>();
                    cfg.CreateMap<DtoUtente, Utente>();

                    cfg.CreateMap<CreateAcquisto, Acquisto>();
                    cfg.CreateMap<ReadAcquisto, Acquisto>();
                    cfg.CreateMap<UpdateAcquisto, Acquisto>();
                    cfg.CreateMap<DeleteAcquisto, Acquisto>();
                }));

            Repository = repository;
        }

        #region Utente

        public DtoUtente CreateUtente(CreateUtente createUtente)
        {
            return Mapper.Map<DtoUtente>(Repository.CreateUtente(Mapper.Map<Utente>(createUtente)));
        }

        public List<DtoUtente> SearchUtente(ReadUtente readUtente)
        {
            return Repository.SearchUtente(Mapper.Map<Utente>(readUtente)).Select(u => Mapper.Map<DtoUtente>(u)).ToList();
        }

        public DtoUtente EditUtente(UpdateUtente updateUtente)
        {
            return Mapper.Map<DtoUtente>(Repository.EditUtente(Mapper.Map<Utente>(updateUtente)));
        }

        public DtoUtente DeleteUtente(DeleteUtente deleteUtente)
        {
            return Mapper.Map<DtoUtente>(Repository.DeleteUtente(Mapper.Map<Utente>(deleteUtente)));
        }

        public DtoUtente GetUtenteById(long id)
        {
            return Mapper.Map<DtoUtente>(Repository.GetUtenteById(id));
        }

        #endregion

        #region Prodotto

        public DtoProdotto CreateProdotto(CreateProdotto createProdotto)
        {
            throw new NotImplementedException();
        }

        public List<DtoProdotto> ReadProdotto(ReadProdotto readProdotto, bool hideOutOfStockItems = true)
        {
            throw new NotImplementedException();
        }

        public DtoProdotto? UpdateProdotto(UpdateProdotto updateProdotto)
        {
            throw new NotImplementedException();
        }

        public DtoProdotto DeleteProdotto(DeleteProdotto deleteProdotto)
        {
            throw new NotImplementedException();
        }

        public DtoProdotto? GetByIdProdotto(long id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Acquisto

        public DtoAcquisto? CreateAcquisto(CreateAcquisto createAcquisto)
        {
            throw new NotImplementedException();
        }

        public List<DtoAcquisto> ReadAcquisto(ReadAcquisto readAcquisto)
        {
            throw new NotImplementedException();
        }

        public DtoAcquisto? UpdateAcquisto(UpdateAcquisto updateAcquisto)
        {
            throw new NotImplementedException();
        }

        public DtoAcquisto DeleteAcquisto(DeleteAcquisto deleteAcquisto)
        {
            throw new NotImplementedException();
        }

        public DtoAcquisto? GetByIdAcquisto(long id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}