using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Services;

public interface IUserService
{
    void CreateUser(UserDto userDto);
    public User GetUserByEmail(UserLogin user);
    bool CheckForUsers();
}