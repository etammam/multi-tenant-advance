using System;
using System.Linq;
using FluentAssertions;
using MultiTenant.Catalog.Domain.Entities;
using Xunit;

namespace MultiTenant.Catalog.Domain.Tests;

public class PlanTests
{
    [Fact]
    public void SetName_WhenCalled_ShouldSetInstanceName()
    {
        //Given
        var instance = new Plan();
        const string name = "plan name";
        //When
        instance.SetName(name);
        //Then
        instance.Name.Should().Be(name);
    }

    [Fact]
    public void SetName_WhenCalled_WithNullOrEmpty_ShouldSetInstanceName()
    {
        //Given
        var instance = new Plan();
        const string name = "";
        const string exceptionMessage = "Plan name is required (Parameter 'name')";
        //When
        var action = () => instance.SetName(name);
        //Then
        action.Should().Throw<ArgumentException>()
            .WithMessage(exceptionMessage);
    }

    [Fact]
    public void SetDescription_WhenCalled_ShouldSetInstanceDescription()
    {
        //Give
        var instance = new Plan();
        const string description =
            "Along age be rake few den to joyless resolved scape the bower friend loathed bacchanals formed of feere vaunted ye";
        //When
        instance.SetDescription(description);
        //Then
        instance.Description.Should().Be(description);
    }

    [Fact]
    public void SetPrice_WhenCalled_ShouldSetInstancePrice()
    {
        //Give
        var instance = new Plan();
        const decimal price = 1200;
        //When
        instance.SetPrice(price);
        //Then
        instance.Price.Should().Be(price);
    }


    [Fact]
    public void SetMaxUserCount_WhenCalled_ShouldSetInstanceMaxUserCount()
    {
        //Give
        var instance = new Plan();
        const int maxUserCount = 12;
        //When
        instance.SetMaxUserCount(maxUserCount);
        //Then
        instance.MaxUserCount.Should().Be(maxUserCount);
    }

    [Fact]
    public void SetMaxUserCount_WhenCalled_WithOutValue_ShouldSetInstanceMaxUserCount1AsDefaultValue()
    {
        //Give
        var instance = new Plan();
        //When
        instance.SetMaxUserCount();
        //Then
        instance.MaxUserCount.Should().Be(1);
    }

    [Fact]
    public void SetMaxDatabaseSize_WhenCalled_ShouldSetInstanceMaxDatabaseSize()
    {
        //Give
        var instance = new Plan();
        const int maxDatabaseSize = 1024;
        //When
        instance.SetMaxDatabaseSize(maxDatabaseSize);
        //Then
        instance.MaxDatabaseSize.Should().Be(maxDatabaseSize);
    }

    [Fact]
    public void SetMaxDatabaseSize_WhenCalled_WithOutValue_ShouldSetInstanceMaxDatabaseSize10240AsDefaultValue()
    {
        //Give
        var instance = new Plan();
        //When
        instance.SetMaxDatabaseSize();
        //Then
        instance.MaxDatabaseSize.Should().Be(10240);
    }

    [Fact]
    public void SetMaxStorageSize_WhenCalled_ShouldSetInstanceMaxStorageSize()
    {
        //Give
        var instance = new Plan();
        const int maxStorageSize = 1024;
        //When
        instance.SetMaxStorageSize(maxStorageSize);
        //Then
        instance.MaxStorageSize.Should().Be(maxStorageSize);
    }

    [Fact]
    public void SetMaxStorageSize_WhenCalled_WithOutValue_ShouldSetInstanceMaxStorageSize5120AsDefaultValue()
    {
        //Give
        var instance = new Plan();
        //When
        instance.SetMaxStorageSize();
        //Then
        instance.MaxStorageSize.Should().Be(5120);
    }


    [Fact]
    public void SetIsDemo_WhenCalled_ShouldSetInstancePlanBoolValue()
    {
        //Given
        var instance = new Plan();
        var isDemo = true;
        //When
        instance.SetIsDemoPlan(isDemo);
        //Then
        instance.IsDemoPlan.Should().Be(isDemo);
    }

    [Fact]
    public void SetIsDemo_WhenCalled_WithOutProviderValue_ShouldSetInstancePlanValueToFalse()
    {
        //Given
        var instance = new Plan();
        //When
        instance.SetIsDemoPlan();
        //Then
        instance.IsDemoPlan.Should().BeFalse();
    }

    [Fact]
    public void SetExpiry_WhenCalled_ShouldSetTheInstanceExpiry()
    {
        //Given
        var instance = new Plan();
        var expiry = 15;
        //When
        instance.SetExpiry(expiry);
        //Then
        instance.Expiry.Should().Be(expiry);
    }

    [Fact]
    public void SetExpiry_WhenCalled_WithNegativeValue_ShouldThrowArgumentException()
    {
        //Given
        var instance = new Plan();
        var expiry = -15;
        var exceptionMessage = "Expiry should be greater than or equal 0 (Parameter 'expiry')";
        //When
        var action = () => instance.SetExpiry(expiry);
        //Then
        action.Should().Throw<ArgumentException>()
            .WithMessage(exceptionMessage);
    }


    [Fact]
    public void SetSubscriptions_WhenCalled_ShouldFillInstanceListOfSubscriptions()
    {
        //Given
        var instance = new Plan("planName", "description", 10, 10, 1024, 1024, true);
        var planId = instance.Id;
        var planExpiry = instance.Expiry;
        var organizationId = Guid.Parse("252f5f29-9a21-4855-a130-c3180ea1feac");
        var startDate = new DateTime(2023, 1, 1);
        var subscription = new Subscription(planId, startDate, planExpiry, organizationId);
        //When
        instance.SetSubscriptions(subscription);
        //Then
        instance.Subscriptions.Should().HaveCount(1);
        instance.Should().BeEquivalentTo(instance);
        instance.Subscriptions.FirstOrDefault()?.Expiry.Should().Be(planExpiry);
        instance.Subscriptions.FirstOrDefault()?.OrganizationId.Should().Be(organizationId);
        instance.Subscriptions.FirstOrDefault()?.StartDate.Should().Be(startDate);
    }
}