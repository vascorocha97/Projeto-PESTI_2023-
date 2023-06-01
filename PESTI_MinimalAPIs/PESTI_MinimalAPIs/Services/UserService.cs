using System.Security.Cryptography;
using PESTI_MinimalAPIs.Data;
using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Helpers;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Services;

public class UserService : IUserService
{
    private readonly DataContext _dbContext;

    public UserService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateUser(UserDto userDto)
    {
        if (userDto.Name == null || userDto.Password == null || userDto.Email == null)
        {
            throw new ArgumentNullException(nameof(userDto.Name), "User data cannot be null.");
        }
        
        byte[] salt = PasswordUtils.GeneratePasswordSalt();
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = userDto.Name,
            Email = userDto.Email,
            PasswordHash = PasswordUtils.GeneratePasswordHash(userDto.Password, salt),
            PasswordSalt = salt,
            PasswordResetToken = null,
            ResetTokenExpires = null
        };

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public User GetUserByEmail(UserDto user)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == user.Email)!;
    }
    
    public User GetUserByEmail(UserLogin user)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == user.Email)!;
    }
    
    public bool AnyUsersExist()
    {
        return _dbContext.Users.Any();
    }
}