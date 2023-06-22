namespace PESTI_MinimalAPIs.Helpers;

using System.Threading.Tasks;
using Microsoft.Identity.Client;

public static class TokenUtils
{
    public static async Task<string> GetAccessToken(IConfiguration configuration)
    {
        var app = ConfidentialClientApplicationBuilder
            .Create(configuration["Dynamics365:ClientId"]!)
            .WithClientSecret(configuration["Dynamics365:ClientSecret"]!)
            .WithAuthority(configuration["Dynamics365:Authority"]!)
            .Build();

        var result = await app.AcquireTokenForClient(new string[] { $"{configuration["Dynamics365:Resource"]!}/.default" })
            .ExecuteAsync();

        return result.AccessToken;
    }
}