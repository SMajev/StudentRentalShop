namespace StudentRentalShop.user.model;

public class Employee : User
{
    public override int MaxLoans { get; } = 2;

    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
    }
}