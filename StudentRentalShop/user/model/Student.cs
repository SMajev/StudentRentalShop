using DefaultNamespace;

namespace StudentRentalShop.user.model;

public class Student : User
{
    public override int maxLoans { get; } = 2;


    
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}