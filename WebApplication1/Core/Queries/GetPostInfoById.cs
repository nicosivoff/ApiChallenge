using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApplication.DataTransferObjects;
using WebApplication.Domain;

namespace WebApplication.Core.Queries
{
    public class GetPostInfoById : IRequest<Salida>
    {
        public int Id { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetPostInfoById, Salida>
    {
        private HttpClient _httpClient;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IMapper mapper)
        {
            _httpClient = new HttpClient();
            _mapper = mapper;
        }

        public async Task<Salida> Handle(GetPostInfoById request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts");
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("Ha ocurrido un error al obtener la información.");

                ServerPost responseInfo = JsonConvert.DeserializeObject<List<ServerPost>>(response.Content.ReadAsStringAsync().Result).FirstOrDefault(info => info.id == request.Id);
                return _mapper.Map<Salida>(responseInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al obtener la información.", ex);
            }
        }
    }
}
