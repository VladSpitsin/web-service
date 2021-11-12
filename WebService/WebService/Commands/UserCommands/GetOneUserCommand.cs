using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;
using WebService.Mappers;

namespace WebService.Commands.UserCommands
{
    public class GetOneUserCommand : IGetOneCommand<UserDTO>
    {
        private readonly UserRepo _repository;
        private readonly UserToUserDTO _mapper;

        public GetOneUserCommand(UserRepo repository, UserToUserDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserDTO Execute(int id)
        {
            User result = _repository.GetOne(id).Item1;
            UserDTO user = _mapper.Map(result);
            return user;
        }
    }
}
