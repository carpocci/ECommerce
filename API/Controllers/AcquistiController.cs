using Business;
using Business.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AcquistiController : GenericControllerBase
    {
        public AcquistiController(IBusiness business) : base(business) { }

        //[HttpGet(Name = nameof(GetAcquisto))]
        //public List<Acquisto> GetAcquisto(string? query)
        //{
        //    return _acquistiRepo.Read(query);
        //}

        [HttpPost(Name = nameof(PostAcquisto))]
        public DtoAcquisto? PostAcquisto(CreateAcquisto createAcquisto)
        {
            return Business.CreateAcquisto(createAcquisto);
        }

        //[HttpPut(Name = nameof(PutAcquisto))]
        //public Acquisto PutAcquisto(Acquisto acquisto)
        //{
        //    return _acquistiRepo.Update(acquisto);  
        //}

        [HttpDelete(Name = nameof(DeleteAcquisto))]
        public DtoAcquisto DeleteAcquisto(DeleteAcquisto deleteAcquisto)
        {
            return Business.DeleteAcquisto(deleteAcquisto);
        }

        [HttpPost(Name = nameof(GetAcquistoById))]
        public ActionResult<DtoAcquisto> GetAcquistoById(long id)
        {
            try
            {
                DtoAcquisto dtoAcquisto = Business.GetAcquistoById(id);
                return Ok(dtoAcquisto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
