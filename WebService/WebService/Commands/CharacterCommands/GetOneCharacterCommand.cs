using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;
using WebService.Mappers;

namespace WebService.Commands.CharacterCommands
{
    public class GetOneCharacterCommand : IGetOneCommand<CharacterDTO>
    {
        private readonly CharacterRepo _repository;
        private readonly CharacterToCharacterDTO _mapper;

        public GetOneCharacterCommand(CharacterRepo repository, CharacterToCharacterDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CharacterDTO Execute(int id)
        {
            Character result = _repository.GetOne(id).Item1;
            CharacterDTO book = _mapper.Map(result);
            return book;
        }
    }
}
