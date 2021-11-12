using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebService.Models;
using WebService.Commands.Interfaces;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<BookDTO> Get([FromServices] IGetAllCommand<BookDTO> cmd)
        {
            return cmd.Execute();
        }

        [HttpGet("id")]
        public BookDTO GetOne([FromServices] IGetOneCommand<BookDTO> cmd, [FromQuery] int id)
        {
            return cmd.Execute(id);
        }

        [HttpPost]
        public void Post([FromServices] IPostCommand<Book> cmd, [FromBody] Book book)
        {
            cmd.Execute(book);
        }

        [HttpDelete]
        public void Delete([FromServices] IDeleteCommand<Book> cmd, [FromQuery] int id)
        {
            cmd.Execute(id);
        }

        [HttpPut]
        public void Put([FromServices] IPutCommand<Book> cmd, [FromBody] Book book)
        {
            cmd.Execute(book);
        }
    }
}
