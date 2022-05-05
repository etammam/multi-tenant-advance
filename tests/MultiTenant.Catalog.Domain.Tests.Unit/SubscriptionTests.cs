using System;
using FluentAssertions;
using MultiTenant.Catalog.Domain.Entities;
using MultiTenant.Catalog.Domain.Exceptions;
using Xunit;

namespace MultiTenant.Catalog.Domain.Tests;

public class SubscriptionTests
{
    [Fact]
    public void SetOrganizationId_WhenCalled_ShouldSetInstanceOrganizationId()
    {
        //Given
        var instance = new Subscription();
        var organizationId = Guid.Parse("39daf27f-78c6-4143-85ff-7071d1dfccc1");
        //When
        instance.SetOrganizationId(organizationId);
        //Then
        instance.OrganizationId.Should().Be(organizationId);
    }

    [Fact]
    public void SetExpiry_WhenCalled_ShouldSetInstanceExpiry()
    {
        //Given
        var instance = new Subscription();
        const int expiry = 7;
        //When
        instance.SetExpiry(expiry);
        //Then
        instance.Expiry.Should().Be(expiry);
    }

    [Fact]
    public void SetExpiry_WhenCalled_WithNegativeValue_ShouldThrowArgumentException()
    {
        //Given
        var instance = new Subscription();
        const int expiry = -7;
        //When
        var action = () => instance.SetExpiry(expiry);
        //Then
        action.Should().Throw<ArgumentException>()
            .WithMessage("Expiry should be greater than or equal 0 (Parameter 'expiry')");
    }

    [Fact]
    public void SetStartDate_WhenCalled_ShouldSetInstanceStartDate()
    {
        //Given
        var instance = new Subscription();
        var startDate = DateTime.Today.AddDays(5);
        //When
        instance.SetStartDate(startDate);
        //Then
        instance.StartDate.Should().Be(startDate);
    }

    [Fact]
    public void SetStartDate_WhenCalled_WithDateLessThanToday_ShouldThrowSubscriptionStartDateException()
    {
        //Given
        var instance = new Subscription();
        var startDate = DateTime.Today.AddDays(-5);
        //When
        var action = () => instance.SetStartDate(startDate);
        //Then
        action.Should().ThrowExactly<SubscriptionStartDateException>();
    }

    [Fact]
    public void SetPlanId_WhenCalled_ShouldSetInstancePlanId()
    {
        //Given
        var instance = new Subscription();
        var planId = Guid.Parse("d5c07606-391a-4134-92cc-b7fd25e3d766");
        //When
        instance.SetPlanId(planId);
        //Then
        instance.PlanId.Should().Be(planId);
    }

    [Fact]
    public void Constructor_WhenCalled_ShouldFillInstance()
    {
        //Given
        var planId = Guid.Parse("4dbb8e79-5210-4370-9593-3ae32cc8c061");
        var organizationId = Guid.Parse("a3ef2543-9cfc-4650-baca-8f4a66bf95a0");
        const int expiry = 10;
        var startDate = DateTime.Now.AddDays(5);
        var subscriptionId = Guid.Parse("5208d05b-5fab-4432-9a0a-1d7f1db2235e");
        //When
        var instance = new Subscription(startDate, expiry, organizationId);
        var instance2 = new Subscription(planId, startDate, expiry);
        var instance3 = new Subscription(subscriptionId, planId, startDate, expiry);
        var instance4 = new Subscription(subscriptionId, startDate, expiry, organizationId);
        //Then
        instance.StartDate.Should().Be(startDate);
        instance.Expiry.Should().Be(expiry);
        instance.OrganizationId.Should().Be(organizationId);

        instance2.StartDate.Should().Be(startDate);
        instance2.Expiry.Should().Be(expiry);
        instance2.PlanId.Should().Be(planId);

        instance3.StartDate.Should().Be(startDate);
        instance3.Expiry.Should().Be(expiry);
        instance3.PlanId.Should().Be(planId);
        instance3.Id.Should().Be(subscriptionId);

        instance4.StartDate.Should().Be(startDate);
        instance4.Expiry.Should().Be(expiry);
        instance4.OrganizationId.Should().Be(organizationId);
        instance4.Id.Should().Be(subscriptionId);
    }
}