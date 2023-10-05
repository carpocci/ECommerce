using Business;
using Business.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProdottiController : GenericControllerBase
    {
        public ProdottiController(IBusiness business) : base(business) { }


        [HttpGet(Name = nameof(GetProdotto))]
        public List<DtoProdotto> GetProdotto(ReadProdotto readProdotto, bool hideOutOfStockItems = true)
        {
            return Business.ReadProdotto(readProdotto, hideOutOfStockItems);
        }

        [HttpPost(Name = nameof(PostProdotto))]
        public ActionResult<DtoProdotto> PostProdotto(CreateProdotto createProdotto)
        {
            try
            {
                return Ok(Business.CreateProdotto(createProdotto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = nameof(PutProdotto))]
        public ActionResult<DtoProdotto> PutProdotto(UpdateProdotto updateProdotto)
        {
            try
            {
                Business.UpdateProdotto(updateProdotto);
                return CreatedAtRoute(nameof(GetProdottoById), new { updateProdotto.Id }, updateProdotto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(Name = nameof(DeleteProdotto))]
        public DtoProdotto DeleteProdotto(DeleteProdotto deleteProdotto)
        {
            return Business.DeleteProdotto(deleteProdotto);
        }

        [HttpGet(Name = nameof(GetProdottoById))]
        public ActionResult<DtoProdotto> GetProdottoById(long id)
        {
            DtoProdotto? search = Business.GetByIdProdotto(id);
            if (search == null)
            {
                return NotFound();
            }
            return Ok(search);
        }
    }
}
