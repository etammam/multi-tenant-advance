using FluentAssertions;
using MultiTenant.Catalog.Domain.Entities;
using MultiTenant.Catalog.Domain.ValueObjects;
using System;
using Xunit;

namespace MultiTenant.Catalog.Domain.Tests;

public class OrganizationTests
{
    [Fact]
    public void Constructor_WhenCalled_WithExplicitId_ShouldCreateNewInstance()
    {
        var organizationId = Guid.Parse("adb1bf76-68e4-4fc0-9288-6af111554677");
        var businessId = Guid.Parse("c4154a0f-242f-4e8d-a497-0223c0df5c58");
        var instance = new Organization(organizationId, "abc company", "123456", businessId);

        instance.Should().BeEquivalentTo(instance);
    }

    [Fact]
    public void Constructor_WhenCalled_ShouldCreateNewInstance()
    {
        var businessId = Guid.Parse("c4154a0f-242f-4e8d-a497-0223c0df5c58");
        var instance = new Organization("abc company", "123456", businessId);

        instance.Should().BeEquivalentTo(instance);
    }
    [Fact]
    public void SetName_WhenCalled_ShouldSetInstanceName()
    {
        //Given
        const string name = "Organization";
        var instance = new Organization();
        //When
        instance.SetName(name);
        //Then
        instance.Name.Should().Be(name);
    }

    [Fact]
    public void SetName_WhenCalled_WithNullOrEmpty_ShouldThrowArgumentException()
    {
        //Given
        const string name = "";
        var instance = new Organization();
        //When
        var action = () => instance.SetName(name);
        //Then
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void SetLogo_WhenCalled_ShouldSetInstanceLogo()
    {
        //Given
        const string logoUrl = "http://abc.company/example.png";
        var instance = new Organization();
        //When
        instance.SetLogo(logoUrl);
        //Then
        instance.Logo.Should().Be(logoUrl);
    }

    [Fact]
    public void SetContact_WhenCalled_ShouldSetInstanceContact()
    {
        //Given
        var contact = new Contact("website", "email", "011000");
        var instance = new Organization();
        //When
        instance.SetContact(contact);
        //Then
        instance.Contact.Should().Be(contact);
    }

    [Fact]
    public void SetAddress_WhenCalled_ShouldAddNewAddressItemToInstance()
    {
        //Given
        var instance = new Organization();
        var address = new Address("street", "city", "state", "country", "zipCode");
        //When
        instance.SetAddress(address);
        //Then
        instance.Address.Should().ContainInOrder(address);
        instance.Address.Count.Should().Be(1);
    }

    [Fact]
    public void SetVatNumber_WhenCalled_ShouldSetVatNumberToInstance()
    {
        //Given
        var instance = new Organization();
        const string vatNumber = "122232";
        //When
        instance.SetVatNumber(vatNumber);
        //Then
        instance.VatNumber.Should().Be(vatNumber);
    }

    [Fact]
    public void SetBusinessId_WhenCalled_ShouldSetBusinessIdToInstance()
    {
        //Given
        var instance = new Organization();
        var businessId = Guid.Parse("e827863e-ac0e-45ca-934f-76469e7e5db0");
        //When
        instance.SetBusinessId(businessId);
        //Then
        instance.BusinessId.Should().Be(businessId);
    }
}