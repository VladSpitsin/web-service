using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.CharacterCommands
{
    public class DeleteCharacterCommand : IDeleteCommand<Character>
    {
        private readonly CharacterRepo _repository;

        public DeleteCharacterCommand(CharacterRepo repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.Delete(id);
        }
    }
}
