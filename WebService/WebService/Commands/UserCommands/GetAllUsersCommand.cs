using System.Collections.Generic;
using System.Linq;
using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;
using WebService.Mappers;

namespace WebService.Commands.UserCommands
{
    public class GetAllUsersCommand : IGetAllCommand<UserDTO>
    {
        private readonly UserRepo _repository;
        private readonly UserToUserDTO _mapper;

        public GetAllUsersCommand(UserRepo repository, UserToUserDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> Execute()
        {
            IEnumerable<UserDTO> result = (IEnumerable<UserDTO>)_repository.Get().Item1.ToList().Select(x => _mapper.Map(x));
            return result;
        }
    }
}
