using Business;
using Business.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UtentiController : GenericControllerBase
    {
        public UtentiController(IBusiness business) : base(business) { }

        [HttpGet(Name = nameof(ListaUtenti))]
        public List<DtoUtente> ListaUtenti()
        {
            return Business.SearchUtente(new());
        }

        [HttpPost(Name = nameof(CercaUtente))]
        public List<DtoUtente> CercaUtente(ReadUtente utente)
        {
            return Business.SearchUtente(utente);
        }

        [HttpPost(Name = nameof(CreaUtente))]
        public DtoUtente CreaUtente(CreateUtente utente)
        {
            return Business.CreateUtente(utente);
        }

        [HttpPut(Name = nameof(ModificaUtente))]
        public ActionResult<DtoUtente> ModificaUtente(UpdateUtente utente)
        {
            try
            {
                return Ok(Business.EditUtente(utente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(Name = nameof(CancellaUtente))]
        public ActionResult<DtoUtente> CancellaUtente(DeleteUtente utente)
        {
            try
            {
                return Ok(Business.DeleteUtente(utente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
