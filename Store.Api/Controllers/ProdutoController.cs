using Microsoft.AspNetCore.Mvc;
using Store.Api.Application;
using Store.Api.ViewModels;
using Store.Domain.Entities;
using Store.Domain.Model;
using Store.Domain.Repositories;

namespace Store.Api.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet("api/produtos")]
        public IEnumerable<Produto> GetAll(
            [FromServices] ProdutoAppService service)
        {
            return service.GetAll();
        }

        [HttpGet("api/produtos/{id:Guid}")]
        public Produto GetById(
            [FromRoute] Guid id,
            [FromServices] ProdutoAppService service)
        {
            return service.GetById(id);
        }

        [HttpPost("api/produtos")]
        public ResultViewModel Create(
            [FromBody] ProdutoViewModel model,
            [FromServices] ProdutoAppService service)
        {
            return service.Create(model);
        }

        [HttpPut("api/produtos/{id:Guid}")]
        public ResultViewModel Edit(
            [FromRoute] Guid id,
            [FromBody] ProdutoViewModel model,
            [FromServices] ProdutoAppService service)
        {
            return service.Update(id, model);

        }

        [HttpDelete("api/produtos/{id:Guid}")]
        public ResultViewModel Delete(
            [FromRoute] Guid id,
            [FromServices] ProdutoAppService service)
        {
            return service.Delete(id);
        }
    }
}
