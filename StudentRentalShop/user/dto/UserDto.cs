using DefaultNamespace;

namespace StudentRentalShop.user.dto;

public class UserDto
{
    public String FirstName;
    public String LastName;
    public UserType UserType;
    
    public UserDto(string firstName, string lastName,  UserType userType)
    {
        FirstName = firstName;
        LastName = lastName;
        UserType = userType;
    }
}