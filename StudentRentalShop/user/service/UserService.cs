using StudentRentalShop.user.dto;
using StudentRentalShop.user.factory;
using StudentRentalShop.user.model;

namespace StudentRentalShop.user;

public class UserService
{
    private static UserService Instance { get; set; } = null;
    
    private static List<User> users;
    
    private UserService()
    {
    }
    
    public static UserService GetInstance()
    {
        Instance ??= new UserService();
        return Instance;
    }


    public IReadOnlyList<User> GetUsers()
    {
        return users;
    }

    
    public void AddUser(UserDto userDto)
    {
        users.Add(UserFactory.Create(userDto));
    }

    
    public User GetUser(String name, String surname)
    {
        foreach (User user in users) 
        {
            if (user.FirstName == name && user.LastName == surname)
            {
                return user;
            }
        }
        throw  new ArgumentException("User not found");
    }
}