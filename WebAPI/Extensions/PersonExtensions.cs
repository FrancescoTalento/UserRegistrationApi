
using WebAPI.Data.DTO;
using WebAPI.Data.Models;

namespace WebAPI.Extensions
{
    public static class PersonExtensions
    {

        public static User ToEntity(this CreateUserDto createUser)
        {
            if(createUser is null) throw new ArgumentNullException(nameof(createUser));

            return new User()
            {
                UserName = createUser.UserName,
                Email = createUser.Email,
                DateOfBirth = createUser.DateOfBirth,
            };
        }
    }
}
