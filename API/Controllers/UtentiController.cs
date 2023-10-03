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
            return Repository.CercaUtente(new());
        }

        [HttpPost(Name = nameof(CercaUtente))]
        public List<DtoUtente> CercaUtente(ReadUtente readUtente)
        {
            return Repository.CercaUtente(readUtente);
        }

        [HttpPost(Name = nameof(CreaUtente))]
        public DtoUtente CreaUtente(CreateUtente utente)
        {
            return Repository.CreateUtente(utente);
        }

        [HttpPut(Name = nameof(ModificaUtente))]
        public DtoUtente ModificaUtente(UpdateUtente utente)
        {
            return Repository.UpdateUtente(utente);
        }

        [HttpDelete(Name = nameof(CancellaUtente))]
        public Utente CancellaUtente(Utente utente)
        {
            return Repository.DeleteUtente(utente);
        }
    }
}
