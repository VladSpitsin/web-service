using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.UserCommands
{
    public class DeleteUserCommand : IDeleteCommand<User>
    {
        private readonly UserRepo _repository;

        public DeleteUserCommand(UserRepo repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.Delete(id);
        }
    }
}
