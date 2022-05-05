using System;
using FluentAssertions;
using MultiTenant.Catalog.Domain.Entities;
using Xunit;

namespace MultiTenant.Catalog.Domain.Tests;

public class BusinessTests
{
    [Fact]
    public void SetBusinessCtor_WhenCalled_ShouldFillInstanceAsExpected()
    {
        //Given
        const string name = "business name";
        const string description =
            "Which lone by full are he at who since later a visit can sighed had nor day there to she";
        //When
        var instance = new Business(name, description);
        //Then
        instance.Id.Should().NotBeEmpty();
        instance.Id.Should().NotBe(Guid.Empty);
        instance.Name.Should().Be(name);
        instance.Description.Should().Be(description);
    }

    [Fact]
    public void SetBusinessCtor_WhenCalled_WithId_ShouldFillInstanceAsExpected()
    {
        //Given
        var id = Guid.Parse("7875e998-f318-4678-9c57-8c2dae9acb14");
        const string name = "business name";
        const string description =
            "Which lone by full are he at who since later a visit can sighed had nor day there to she";
        //When
        var instance = new Business(id, name, description);
        //Then
        instance.Name.Should().Be(name);
        instance.Description.Should().Be(description);
    }

    [Fact]
    public void SetName_WhenCalled_ShouldSetInstanceName()
    {
        //Given
        var instance = new Business();
        const string name = "business name";
        //When
        instance.SetName(name);
        //Then
        instance.Name.Should().Be(name);
    }

    [Fact]
    public void SetName_WhenCalled_WithNullOrEmptyValue_ShouldThrowArgumentNullException()
    {
        //Given
        var instance = new Business();
        const string name = "";
        //When
        Action action = () => instance.SetName(name);
        //Then
        action.Should().Throw<ArgumentException>()
            .WithMessage("Business name is required (Parameter 'name')");
    }

    [Fact]
    public void SetDescription_WhenCalled_ShouldSetInstanceDescription()
    {
        //Given
        var instance = new Business();
        const string description =
            "Haply sins dear begun flatterers flow riot smile to they knew sad heralds pillared he that say native had pangs";
        //When
        instance.SetDescription(description);
        //Then
        instance.Description.Should().Be(description);
    }
}