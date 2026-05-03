using System;
using CoreFitness.Domain.AppUsers;

namespace CoreFitness.Tests;

public class AppUserEntityTests
{

    // Tests are AI generated

    [Fact]
    public void UpdateUserPersonalInfo_ShouldReplaceUserPersonalInfoValues()
    {
        // Arrange
        var appUser = new AppUserEntity(Guid.NewGuid());

        // Act
        appUser.UpdateUserPersonalInfo("Disney", "Land", "+1234567890");

        // Assert
        Assert.Equal("Disney", appUser.UserPersonalInfo?.FirstName);
        Assert.Equal("Land", appUser.UserPersonalInfo?.LastName);
        Assert.Equal("+1234567890", appUser.UserPersonalInfo?.PhoneNumber);
        Assert.NotEqual(default, appUser.UpdatedAt);
        Assert.True(appUser.UpdatedAt >= appUser.CreatedAt);
    }

    [Fact]
    public void UpdateUserPersonalInfo_WithLongFirstName_ThrowsArgumentException()
    {
        // Arrange
        var appUser = new AppUserEntity(Guid.NewGuid());
        var longFirstName = new string('A', 51);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(
            () => appUser.UpdateUserPersonalInfo(longFirstName, "Doe", "+1234567890"));

        Assert.Contains("First name cannot be longer than 50 characters", exception.Message);
    }

    [Fact]
    public void UpdateUserPersonalInfo_WithLongLastName_ThrowsArgumentException()
    {
        // Arrange
        var appUser = new AppUserEntity(Guid.NewGuid());
        var longLastName = new string('B', 51);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(
            () => appUser.UpdateUserPersonalInfo("Jane", longLastName, "+1234567890"));

        Assert.Contains("Last name cannot be longer than 50 characters", exception.Message);
    }

    [Fact]
    public void UpdateUserPersonalInfo_WithLongPhoneNumber_ThrowsArgumentException()
    {
        // Arrange
        var appUser = new AppUserEntity(Guid.NewGuid());
        var longPhone = new string('9', 31);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(
            () => appUser.UpdateUserPersonalInfo("Jane", "Doe", longPhone));

        Assert.Contains("Phone Number cannot be longer than 50 characters", exception.Message);
    }
}