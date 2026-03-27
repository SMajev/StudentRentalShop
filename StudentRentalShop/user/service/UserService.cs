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

    public void AddUser(User user)
    {
        users.Add(user);
    }
}