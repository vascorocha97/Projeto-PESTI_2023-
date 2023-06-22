using System.Security.Cryptography;
using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Data;
using PESTI_MinimalAPIs.Helpers;
using PESTI_MinimalAPIs.Models;
using PESTI_MinimalAPIs.Services.Users;

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
        //check if data is null
        if (userDto.Name == null || userDto.Password == null || userDto.Email == null)
        {
            throw new ArgumentNullException(nameof(userDto.Name), "User data cannot be empty.");
        }
        
        //Generates password salt
        byte[] salt = PasswordUtils.GeneratePasswordSalt();
        
        //Creates user
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = userDto.Name,
            Email = userDto.Email,
            //Uses the previously generated password salt and the user password to generate the hash 
            PasswordHash = PasswordUtils.GeneratePasswordHash(userDto.Password, salt),
            PasswordSalt = salt
        };

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
    
    public User GetUserByEmail(UserLogin user)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == user.Email)!;
    }
    
    public bool CheckForUsers()
    {
        //check if there are any users in the db
        return _dbContext.Users.Any();
    }
}