using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Services;

namespace PESTI_MinimalAPIs.Data;

public class UserDataSeeder
{
    public static void SeedUsers(IUserService userService)
    {
        if (!userService.AnyUsersExist())
        {
            var users = new List<UserDto>
            {
                new UserDto
                {
                    Name = "John Doe",
                    Email = "john@example.com",
                    Password = "password1"
                },
                new UserDto
                {
                    Name = "Jane Smith",
                    Email = "jane@example.com",
                    Password = "password2"
                }
                // Add more users as needed
            };

            foreach (var userDto in users)
            {
                userService.CreateUser(userDto);
            }
        }
    }

}