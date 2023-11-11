using DDD.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerarRelatorioController : ControllerBase
    {
        private readonly ApplicationServiceGerarRelatorio _applicationServiceGerarRelatorio;

        public GerarRelatorioController(ApplicationServiceGerarRelatorio applicationServiceGerarRelatorio)
        {
            _applicationServiceGerarRelatorio = applicationServiceGerarRelatorio;
        }

        [HttpPost()]
        [Route("GerarRelatorio")]
        public void GerarRelatorio(bool ead)
        {
            _applicationServiceGerarRelatorio.GerarRelatorio(ead);
        }
    }
}
