namespace CoreFitness.Domain.AppUsers;

public class AppUserPersonalInfo
{
    public string? FirstName { get; }
    public string? LastName { get; }
    public string? PhoneNumber { get; }

    public AppUserPersonalInfo(string? firstName, string? lastName, string? phoneNumber)
    {
        if (firstName?.Length > 50)
            throw new ArgumentException("First name cannot be longer than 50 characters");

        if (lastName?.Length > 50)
            throw new ArgumentException("Last name cannot be longer than 50 characters");

        if (phoneNumber?.Length > 30)
            throw new ArgumentException("Phone Number cannot be longer than 50 characters");

        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
}