using StudentRentalShop.user.modelenum;

namespace StudentRentalShop.user.dto;

public class UserDto
{
    public readonly string FirstName;
    public readonly string LastName;
    public readonly UserType UserType;
    
    public UserDto(string firstName, string lastName,  UserType userType)
    {
        FirstName = firstName;
        LastName = lastName;
        UserType = userType;
    }
}