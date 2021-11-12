using WebService.Models;

namespace WebService.Mappers
{
    public class UserToUserDTO : IMapper<User, UserDTO>
    {
        public UserDTO Map(User user)
        {
            if (user is null)
            {
                return null;
            }
            else
            {
                return new UserDTO { Name = user.Name, Age = user.Age };
            }
        }
    }
}
