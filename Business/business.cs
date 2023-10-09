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

                    cfg.CreateMap<Acquisto, DtoAcquisto>();
                    cfg.CreateMap<DtoAcquisto, Acquisto>();

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
            return Mapper.Map<DtoProdotto>(Repository.CreateProdotto(Mapper.Map<Prodotto>(createProdotto)));
        }

        public List<DtoProdotto> SearchProdotto(ReadProdotto readProdotto, bool hideOutOfStockItems = true)
        {
            return Repository.SearchProdotto(Mapper.Map<Prodotto>(readProdotto)).Select(p => Mapper.Map<DtoProdotto>(p)).ToList();
        }

        public DtoProdotto? EditProdotto(UpdateProdotto updateProdotto)
        {
            return Mapper.Map<DtoProdotto>(Repository.EditProdotto(Mapper.Map<Prodotto>(updateProdotto)));
        }

        public DtoProdotto DeleteProdotto(DeleteProdotto deleteProdotto)
        {
            return Mapper.Map<DtoProdotto>(Repository.DeleteProdotto(Mapper.Map<Prodotto>(deleteProdotto)));
        }

        public DtoProdotto? GetProdottoById(long id)
        {
            return Mapper.Map<DtoProdotto>(Repository.GetProdottoById(id));
        }

        #endregion

        #region Acquisto

        public DtoAcquisto? CreateAcquisto(CreateAcquisto createAcquisto)
        {
            return Mapper.Map<DtoAcquisto>(Repository.CreateAcquisto(Mapper.Map<Acquisto>(createAcquisto)));
        }

        public List<DtoAcquisto> SearchAcquisto(ReadAcquisto readAcquisto)
        {
            return Repository.SearchAcquisto(Mapper.Map<Acquisto>(readAcquisto)).Select(p => Mapper.Map<DtoAcquisto>(p)).ToList();
        }

        public DtoAcquisto? EditAcquisto(UpdateAcquisto updateAcquisto)
        {
            return Mapper.Map<DtoAcquisto>(Repository.EditAcquisto(Mapper.Map<Acquisto>(updateAcquisto)));
        }

        public DtoAcquisto DeleteAcquisto(DeleteAcquisto deleteAcquisto)
        {
            return Mapper.Map<DtoAcquisto>(Repository.DeleteAcquisto(Mapper.Map<Acquisto>(deleteAcquisto)));
        }

        public DtoAcquisto GetAcquistoById(long id)
        {
            return Mapper.Map<DtoAcquisto>(Repository.GetAcquistoById(id));
        }

        #endregion
    }
}