using DefaultNamespace;

namespace StudentRentalShop.user.model;


public abstract class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; }
    public string LastName { get; }

    public abstract int MaxLoans { get; }
    
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}