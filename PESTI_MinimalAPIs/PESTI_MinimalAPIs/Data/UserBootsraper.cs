using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Services;
using PESTI_MinimalAPIs.Services.Users;

namespace PESTI_MinimalAPIs.Data;

public class UserBootsraper
{
    public static void SeedUsers(IUserService userService)
    {
        if (!userService.CheckForUsers())
        {
            var exampleUsers = new List<UserDto>
            {
                new UserDto
                {
                    Name = "Vasco Rocha",
                    Email = "vasco@rocha.com",
                    Password = "vascorocha"
                },
                new UserDto
                {
                    Name = "Manuel Miolo",
                    Email = "manuel@miolo.com",
                    Password = "manuelmiolo"
                }
            };

            foreach (var userDto in exampleUsers)
            {
                userService.CreateUser(userDto);
            }
        }
    }

}