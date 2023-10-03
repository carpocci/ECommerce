using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelli;
using Modelli.Repository;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProdottiController : GenericControllerBase
    {
        public ProdottiController(IRepository repository) : base(repository) { }


        [HttpGet(Name = nameof(GetProdotto))]
        public List<Prodotto> GetProdotto(string query = "", bool hideOutOfStockItems = true)
        {
            return Repository.ReadProdotto(query, hideOutOfStockItems);
        }

        [HttpPost(Name = nameof(PostProdotto))]
        public ActionResult<Prodotto> PostProdotto(Prodotto prodotto)
        {
            try
            {
                return Ok(Repository.CreateProdotto(prodotto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = nameof(PutProdotto))]
        public ActionResult<Prodotto> PutProdotto(Prodotto prodotto)
        {
            try
            {
                Repository.UpdateProdotto(prodotto);
                return CreatedAtRoute(nameof(GetProdottoById), new { prodotto.Id }, prodotto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(Name = nameof(DeleteProdotto))]
        public Prodotto DeleteProdotto(Prodotto prodotto)
        {
            return Repository.DeleteProdotto(prodotto);
        }

        [HttpGet(Name = nameof(GetProdottoById))]
        public ActionResult<Prodotto> GetProdottoById(long id)
        {
            Prodotto? search = Repository.GetByIdProdotto(id);
            if (search == null)
            {
                return NotFound();
            }
            return Ok(search);
        }
    }
}
