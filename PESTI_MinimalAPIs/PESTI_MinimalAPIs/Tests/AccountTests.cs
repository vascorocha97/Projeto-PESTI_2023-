using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Models;
using PESTI_MinimalAPIs.Services.Accounts;
using Xunit;

namespace PESTI_MinimalAPIs.Tests;

public class AccountTests
{
    private readonly TestServer _server;
    private readonly HttpClient _client;

    public AccountTests()
    {
        _server = new TestServer(new WebHostBuilder()
            .UseStartup<Program>());

        _client = _server.CreateClient();
    }

    [Fact]
    public async Task CreateAccountEndpointTest()
    {
        // Arrange
        var requestData = new CreateAccountRequest
        {
            Name = "Test Account",
            Phone = "123456789",
            Fax = "987654321",
            Website = "https://example.com",
            ParentAccount = Guid.Parse("a16b3f4b-1be7-e611-8101-e0071b6af231"),
            Ticker = "TEST",
            RelationshipField = 1
        };

        // Act
        var response = await _client.PostAsJsonAsync("/createaccount", requestData);
        response.EnsureSuccessStatusCode();

        var createdAccount = await response.Content.ReadFromJsonAsync<Account>();

        // Assert
        Assert.Equal(requestData.Name, createdAccount.Name);
        Assert.Equal(requestData.Phone, createdAccount.Phone);
        Assert.Equal(requestData.Fax, createdAccount.Fax);
        Assert.Equal(requestData.Website, createdAccount.Website);
        Assert.Equal(requestData.ParentAccount, createdAccount.ParentAccount);
        Assert.Equal(requestData.Ticker, createdAccount.Ticker);
        Assert.Equal(requestData.RelationshipField, createdAccount.RelationshipField);
    }
}