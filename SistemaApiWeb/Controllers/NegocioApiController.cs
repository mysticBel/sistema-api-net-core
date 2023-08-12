using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaApiWeb.Entidades;

using SistemaApiWeb.Entidades;
using SistemaApiWeb.DAO;

namespace SistemaApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioApiController : ControllerBase
    {
        [HttpGet("GetPaises")]
        public async Task<ActionResult<List<Pais>>> GetPais() 
        {
            var lista = await Task.Run(() => (new PaisDAO()).GetPaises());
            return Ok(lista);  //okObjectResult rpta
        }
    }
}
