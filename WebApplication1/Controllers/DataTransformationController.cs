using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Core.Queries;
using WebApplication.DataTransferObjects;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTransformationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataTransformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public Task<Salida> GetPostInfoInfo([FromRoute]GetPostInfoById query)
        {
            return _mediator.Send(query);
        }
    }
}
