using System.Dynamic;

namespace CoreFitness.Domain.AppUser;

public class AppUserEntity
{
    public Guid Id { get; private set; }
    public Guid IdentityUserId { get; private set; }

    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? PhoneNumber { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }


    // Code from row 21 and down is AI generated

    // Private Constructor (prevents creating invalid objects from the outside and for EF core when loading from database)
    private AppUserEntity() {}

    // Public Constructor (for creating a valid user)
    public AppUserEntity (Guid identityUserId)
    {
        Id = Guid.NewGuid();
        IdentityUserId = identityUserId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    // Method for updating personal user information
    public void UpdateUserPersonalInfo(string? firstName, string? lastName, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
}