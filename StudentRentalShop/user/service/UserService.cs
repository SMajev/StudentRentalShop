using StudentRentalShop.user.dto;
using StudentRentalShop.user.factory;
using StudentRentalShop.user.model;

namespace StudentRentalShop.user;

public class UserService
{
    private static UserService _instance;
    private static readonly List<User> _users = new List<User>();
    
    private UserService()
    {
    }
    
    public static UserService Instance()
    {
        _instance ??= new UserService();
        return _instance;
    }


    public IReadOnlyList<User> GetUsers()
    {
        return _users;
    }

    
    public void AddUser(UserDto userDto)
    {
        _users.Add(UserFactory.Create(userDto));
    }

    
    public User GetUserByNameLastName(String name, String surname)
    {
        return _users
            .FirstOrDefault(user => user.FirstName == name &&  user.LastName == surname)
                ?? throw new KeyNotFoundException("User not found");

    }
    
    public User GetUserById(Guid id)
    {
        return _users
                   .FirstOrDefault(user => user.Id == id)
               ?? throw new KeyNotFoundException("User not found");
    }
}