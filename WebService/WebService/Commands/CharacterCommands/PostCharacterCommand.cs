using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.CharacterCommands
{
    public class PostCharacterCommand : IPostCommand<Character>
    {
        private readonly CharacterRepo _repository;

        public PostCharacterCommand(CharacterRepo repository)
        {
            _repository = repository;
        }

        public void Execute(Character character)
        {
            _repository.Post(character);
        }
    }
}
