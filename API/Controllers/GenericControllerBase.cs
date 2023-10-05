using Business;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GenericControllerBase : ControllerBase
    {
        protected IBusiness Business { get; }

        public GenericControllerBase(IBusiness business)
        {
            Business = business;
        }
    }
}
