namespace CoreFitness.Domain.AppUsers;

public class AppUserEntity
{
    public Guid Id { get; private set; }
    public Guid IdentityUserId { get; private set; }

    public AppUserPersonalInfo UserPersonalInfo { get; private set; } = null!;

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
        UserPersonalInfo = new AppUserPersonalInfo(firstName, lastName, phoneNumber);
        UpdatedAt = DateTime.UtcNow;
    }
}