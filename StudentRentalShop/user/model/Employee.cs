namespace StudentRentalShop.user.model;

public class Employee : User
{
    public override int maxLoans { get; } = 2;

    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}