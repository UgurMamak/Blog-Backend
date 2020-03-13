using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Persistence.Entity;


namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AbstractController : ControllerBase
    {
        protected readonly BlogDbContext Context;
        public AbstractController(BlogDbContext context)
        {
            Context = context;
        }
    }
}