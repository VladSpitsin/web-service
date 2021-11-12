using WebService.Models;

namespace WebService.Mappers
{
    public class CharacterToCharacterDTO : IMapper<Character, CharacterDTO>
    {
        public CharacterDTO Map(Character character)
        {
            if (character is null)
            {
                return null;
            }
            else
            {
                return new CharacterDTO { Name = character.Name, NickName = character.NickName, Planet = character.Planet };
            }
        }
    }
}
