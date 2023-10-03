using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelli;
using Modelli.Repository;
using AutoMapper;

namespace API.Controllers
{
    public class GenericControllerBase : ControllerBase
    {
        protected IRepository Repository { get; }

        public GenericControllerBase(IRepository repository)
        {
            Repository = repository;
        }
    }
}
