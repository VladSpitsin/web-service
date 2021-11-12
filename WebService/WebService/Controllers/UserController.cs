using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebService.Models;
using WebService.Commands.Interfaces;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UserDTO> Get([FromServices] IGetAllCommand<UserDTO> cmd)
        {
            return cmd.Execute();
        }

        [HttpGet("id")]
        public UserDTO GetOne([FromServices] IGetOneCommand<UserDTO> cmd, [FromQuery] int id)
        {
            return cmd.Execute(id);
        }

        [HttpPost]
        public void Post([FromServices] IPostCommand<User> cmd, [FromBody] User user)
        {
            cmd.Execute(user);
        }

        [HttpDelete]
        public void Delete([FromServices] IDeleteCommand<User> cmd, [FromQuery] int id)
        {
            cmd.Execute(id);
        }

        [HttpPut]
        public void Put([FromServices] IPutCommand<User> cmd, [FromBody] User user)
        {
            cmd.Execute(user);
        }
    }
}
