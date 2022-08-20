using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTransformationController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(int id)
        {
        }
    }
}
