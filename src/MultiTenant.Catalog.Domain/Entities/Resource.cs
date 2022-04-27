using Ardalis.GuardClauses;
using Enigma.String;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Domain.Enums;
using MultiTenant.Shared.Abstraction.Constants;

namespace MultiTenant.Catalog.Domain.Entities;

public class Resource : BaseEntity, IAggregateRoot
{
    public Resource(Guid id, string name,
        string description,
        string serverAddress,
        int serverPort,
        string serverUserName,
        string serverPassword,
        DatabaseProvider databaseProvider,
        ResourceType resourceType,
        ServerType serverType,
        int capacity)
    {
        Id = id;
        SetResourceName(name);
        SetDescription(description);
        SetServerAddress(serverAddress);
        SetServerPort(serverPort);
        SetServerUserName(serverUserName);
        SetServerPassword(serverPassword);
        SetDatabaseProvider(databaseProvider);
        SetResourceType(resourceType);
        SetServerType(serverType);
        SetCapacity(capacity);


        var options = new EnigmaOptions(ApplicationConstants.EncryptionSalt);
        EnigmaExtension.SetOptions(options);
    }

    public Resource(string name,
        string description,
        string serverAddress,
        int serverPort,
        string serverUserName,
        string serverPassword,
        DatabaseProvider databaseProvider,
        ResourceType resourceType,
        ServerType serverType,
        int capacity)
        : this(Guid.NewGuid(), name, description, serverAddress, serverPort, serverUserName, serverPassword,
            databaseProvider, resourceType, serverType, capacity)
    {
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string ServerAddress { get; private set; }

    public int ServerPort { get; private set; }

    public string ServerUserName { get; private set; }

    public string ServerPassword { get; private set; }


    public DatabaseProvider DatabaseProvider { get; private set; }


    public ResourceType ResourceType { get; private set; }

    public ServerType ServerType { get; private set; }

    public int Capacity { get; private set; }

    public ICollection<Tenant> Tenants { get; set; }

    public Resource SetResourceName(string name)
    {
        Guard.Against.NullOrEmpty(name, nameof(name), "Resource name is required");
        Guard.Against.NullOrWhiteSpace(name, nameof(name), "Resource name is required");
        Name = name;
        return this;
    }


    public Resource SetDescription(string description)
    {
        Description = description;
        return this;
    }

    public Resource SetServerAddress(string serverAddress)
    {
        ServerAddress = Guard.Against.NullOrWhiteSpace(serverAddress,
            nameof(serverAddress),
            "Server address is required");
        return this;
    }

    public Resource SetServerPort(int serverPort)
    {
        Guard.Against.OutOfRange(serverPort,
            nameof(serverPort),
            1,
            65535,
            "Server port must be between 1 and 65535");
        ServerPort = serverPort;
        return this;
    }

    public Resource SetServerUserName(string serverUserName)
    {
        ServerUserName = Guard.Against.NullOrWhiteSpace(serverUserName, serverUserName, "Server user name is required");
        return this;
    }

    public Resource SetServerPassword(string serverPassword)
    {
        //if password is not null we need to encrypt it
        if (!string.IsNullOrWhiteSpace(serverPassword))
            serverPassword = serverPassword.Encrypt();
        ServerPassword = serverPassword;
        return this;
    }

    public Resource SetDatabaseProvider(DatabaseProvider databaseProvider)
    {
        DatabaseProvider = databaseProvider;
        return this;
    }

    public Resource SetResourceType(ResourceType resourceType)
    {
        ResourceType = resourceType;
        return this;
    }

    public Resource SetServerType(ServerType serverType)
    {
        ServerType = serverType;
        return this;
    }

    public Resource SetCapacity(int capacity)
    {
        Capacity = Guard.Against.NegativeOrZero(capacity, nameof(capacity), "Capacity must be greater than 0");
        return this;
    }
}