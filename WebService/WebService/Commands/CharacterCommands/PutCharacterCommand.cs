using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.CharacterCommands
{
    public class PutCharacterCommand : IPutCommand<Character>
    {
        private readonly CharacterRepo _repository;

        public PutCharacterCommand(CharacterRepo repository)
        {
            _repository = repository;
        }

        public void Execute(Character character)
        {
            _repository.Put(character);
        }
    }
}
