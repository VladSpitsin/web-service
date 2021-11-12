using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebService.Models;
using WebService.Commands.Interfaces;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ProductDTO> Get([FromServices] IGetAllCommand<ProductDTO> cmd)
        {
            return cmd.Execute();
        }

        [HttpGet("id")]
        public ProductDTO GetOne([FromServices] IGetOneCommand<ProductDTO> cmd, [FromQuery] int id)
        {
            return cmd.Execute(id);
        }

        [HttpPost]
        public void Post([FromServices] IPostCommand<Product> cmd, [FromBody] Product product)
        {
            cmd.Execute(product);
        }

        [HttpDelete]
        public void Delete([FromServices] IDeleteCommand<Product> cmd, [FromQuery] int id)
        {
            cmd.Execute(id);
        }

        [HttpPut]
        public void Put([FromServices] IPutCommand<Product> cmd, [FromBody] Product product)
        {
            cmd.Execute(product);
        }
    }
}
