namespace StudentRentalShop.user.model;

public class Employee : User
{
    public override int maxLoans { get; } = 2;

    public Employee(string firstName, string lastName, int maxLoans) : base(firstName, lastName)
    {
        this.maxLoans = maxLoans;
    }
}