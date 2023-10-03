using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelli;
using Modelli.Repository;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AcquistiController : GenericControllerBase
    {
        public AcquistiController(IRepository repository) : base(repository) { }

        //[HttpGet(Name = nameof(GetAcquisto))]
        //public List<Acquisto> GetAcquisto(string? query)
        //{
        //    return _acquistiRepo.Read(query);
        //}

        [HttpPost(Name = nameof(PostAcquisto))]
        public Acquisto? PostAcquisto(Acquisto acquisto)
        {
            return Repository.CreateAcquisto(acquisto);
        }

        //[HttpPut(Name = nameof(PutAcquisto))]
        //public Acquisto PutAcquisto(Acquisto acquisto)
        //{
        //    return _acquistiRepo.Update(acquisto);  
        //}

        [HttpDelete(Name = nameof(DeleteAcquisto))]
        public Acquisto DeleteAcquisto(Acquisto acquisto)
        {
            return Repository.DeleteAcquisto(acquisto);
        }
    }
}
