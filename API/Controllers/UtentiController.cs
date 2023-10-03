using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelli;
using Modelli.Repository;
using Modelli.Dto;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UtentiController : GenericControllerBase
    {
        public UtentiController(IRepository repository) : base(repository) { }

        [HttpGet(Name = nameof(ListaUtenti))]
        public List<DtoUtente> ListaUtenti()
        {
            return Repository.SearchUtente(new());
        }

        [HttpPost(Name = nameof(CercaUtente))]
        public List<DtoUtente> CercaUtente(ReadUtente utente)
        {
            return Repository.SearchUtente(utente);
        }

        [HttpPost(Name = nameof(CreaUtente))]
        public DtoUtente CreaUtente(CreateUtente utente)
        {
            return Repository.CreateUtente(utente);
        }

        [HttpPut(Name = nameof(ModificaUtente))]
        public DtoUtente ModificaUtente(UpdateUtente utente)
        {
            return Repository.EditUtente(utente);
        }

        [HttpDelete(Name = nameof(CancellaUtente))]
        public DtoUtente CancellaUtente(DeleteUtente utente)
        {
            return Repository.DeleteUtente(utente);
        }
    }
}
