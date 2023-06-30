using System.Net;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using PESTI_MinimalAPIs.Models;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace PESTI_MinimalAPIs.Tests;

public class AccountTests
{
    private readonly TestServer _server;
    private readonly HttpClient _client;

    public AccountTests()
    {
        //create a test server 
        _server = new TestServer(new WebHostBuilder().UseStartup<Program>());
        _client = _server.CreateClient();
    }

    [Fact]
    public async Task CreateAccountTest()
    {
        var testAccount = new StringContent(@"{
        ""Name"": ""Conta Teste"",
        ""Phone"": ""1234567890"",
        ""Fax"": ""9876543210"",
        ""Website"": ""http://www.teste.com"",
        ""ParentAccount"": ""a16b3f4b-1be7-e611-8101-e0071b6af231"",
        ""Ticker"": ""TICKER"",
        ""RelationshipField"": 2
        }", Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("/createaccount", testAccount);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task UpdateAccountTest()
    {
        var testAccount = new StringContent(@"{
        ""Id"": ""Conta Update"",
        ""Name"": ""Conta Update"",
        ""Phone"": ""1234567890"",
        ""Fax"": ""9876543210"",
        ""Website"": ""http://www.update.com"",
        ""ParentAccount"": ""a16b3f4b-1be7-e611-8101-e0071b6af231"",
        ""Ticker"": ""TICKER"",
        ""RelationshipField"": 2
        }", Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("/createaccount", testAccount);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    public void Dispose()
    {
        // Dispose the TestServer and HttpClient
        _client.Dispose();
        _server.Dispose();
    }
}