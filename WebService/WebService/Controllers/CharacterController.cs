using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebService.Models;
using WebService.Commands.Interfaces;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CharacterDTO> Get([FromServices] IGetAllCommand<CharacterDTO> cmd)
        {
            return cmd.Execute();
        }

        [HttpGet("id")]
        public CharacterDTO GetOne([FromServices] IGetOneCommand<CharacterDTO> cmd, [FromQuery] int id)
        {
            return cmd.Execute(id);
        }

        [HttpPost]
        public void Post([FromServices] IPostCommand<Character> cmd, [FromBody] Character character)
        {
            cmd.Execute(character);
        }

        [HttpDelete]
        public void Delete([FromServices] IDeleteCommand<Character> cmd, [FromQuery] int id)
        {
            cmd.Execute(id);
        }

        [HttpPut]
        public void Put([FromServices] IPutCommand<Character> cmd, [FromBody] Character character)
        {
            cmd.Execute(character);
        }
    }
}
