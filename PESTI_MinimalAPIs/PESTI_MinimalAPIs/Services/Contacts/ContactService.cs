using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Helpers;
using PESTI_MinimalAPIs.Mappers;
using PESTI_MinimalAPIs.Services.Contacts;
using RestSharp;

namespace PESTI_MinimalAPIs.Services;

public class ContactService : IContactService
{
    private readonly ContactMapper _contactMapper;
    private readonly IConfiguration _configuration;
    
    public ContactService(IConfiguration configuration)
    {
        _configuration = configuration;
        _contactMapper = new ContactMapper();
    }
    
    public async Task<ContactDto> CreateContact(ContactDto contact)
    {
        var accessToken = await TokenUtils.GetAccessToken(_configuration);

        var client = new RestClient(_configuration["Dynamics365:BaseUrl"]!);
        var request = new RestRequest("myp_createContact", Method.Post);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        request.AddJsonBody(contact);

        var result = await client.ExecuteAsync(request);
        return contact;
    }
}