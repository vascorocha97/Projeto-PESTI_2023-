using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Services.Users;

public interface IUserService
{
    void CreateUser(UserDto userDto);
    public User GetUserByEmail(UserLogin user);
    bool CheckForUsers();
}