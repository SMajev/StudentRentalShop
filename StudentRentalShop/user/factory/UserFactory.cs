using DefaultNamespace;
using StudentRentalShop.user.dto;
using StudentRentalShop.user.model;

namespace StudentRentalShop.user.factory;

public class UserFactory
{
    public static User Create(UserDto userDto)
    {
        return userDto.UserType switch
        {
            UserType.Student => new Student(userDto.FirstName, userDto.LastName),
            UserType.Employee => new Employee(userDto.FirstName, userDto.LastName),

            _ => throw new ArgumentException("Unknown type")
        };
    }
}