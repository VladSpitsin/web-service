using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.UserCommands
{
    public class PostUserCommand : IPostCommand<User>
    {
        private readonly UserRepo _repository;

        public PostUserCommand(UserRepo repository)
        {
            _repository = repository;
        }

        public void Execute(User user)
        {
            _repository.Post(user);
        }
    }
}
