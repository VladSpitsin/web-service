using System.Collections.Generic;
using System.Linq;
using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;
using WebService.Mappers;

namespace WebService.Commands.CharacterCommands
{
    public class GetAllCharactersCommand : IGetAllCommand<CharacterDTO>
    {
        private readonly CharacterRepo _repository;
        private readonly CharacterToCharacterDTO _mapper;

        public GetAllCharactersCommand(CharacterRepo repository, CharacterToCharacterDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CharacterDTO> Execute()
        {
            var characters = _repository.Get();
            var resulting_characters = characters.ToList()
                .Select(x => _mapper.Map(x));
            return resulting_characters;
        }
    }
}
