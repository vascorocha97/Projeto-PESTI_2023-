using Newtonsoft.Json;
using PESTI_MinimalAPIs.Contracts.Contacts;
using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Helpers;
using PESTI_MinimalAPIs.Mappers.Contacts;
using PESTI_MinimalAPIs.Mappers.Incidents;
using PESTI_MinimalAPIs.Models;
using RestSharp;

namespace PESTI_MinimalAPIs.Services.Contacts;

public class ContactService : IContactService
{
    private readonly CRMContactResponseMapper _crmContactResponseMapper;
    private readonly IConfiguration _configuration;
    
    public ContactService(IConfiguration configuration)
    {
        _configuration = configuration;
        _crmContactResponseMapper = new CRMContactResponseMapper();
    }
    
    public async Task<Contact?> CreateContact(CRMContact contactRequest)
    {
        var accessToken = await TokenUtils.GetAccessToken(_configuration);

        var client = new RestClient(_configuration["Dynamics365:BaseUrl"]!);
        var request = new RestRequest("myp_createContact", Method.Post);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        request.AddJsonBody(contactRequest);

        var result = await client.ExecuteAsync(request);

        if (!result.IsSuccessStatusCode) return null;
        
        var createdContact = JsonConvert.DeserializeObject<CRMContactResponse>(result.Content!);
        return createdContact is null ? null : _crmContactResponseMapper.CRMContactResponseToContact(createdContact);
    }
    
    public async Task<Contact?> GetContactById (CRMContactId crmContactId)
    {
        var accessToken = await TokenUtils.GetAccessToken(_configuration);

        var client = new RestClient(_configuration["Dynamics365:BaseUrl"]!);
        var request = new RestRequest("myp_getContactById", Method.Post);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        request.AddJsonBody(crmContactId);

        var result = await client.ExecuteAsync(request);

        if (!result.IsSuccessStatusCode) return null;

        var contact = JsonConvert.DeserializeObject<CRMContactResponse>(result.Content!);
        return contact is null ? null : _crmContactResponseMapper.CRMContactResponseToContact(contact);
    }

    public async Task<Contact?> UpdateContact(CRMUpdateContactRequest crmUpdateContactRequest)
    {
        var accessToken = await TokenUtils.GetAccessToken(_configuration);

        var client = new RestClient(_configuration["Dynamics365:BaseUrl"]!);
        var request = new RestRequest("myp_updateContact", Method.Post);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        request.AddJsonBody(crmUpdateContactRequest);

        var result = await client.ExecuteAsync(request);

        if (!result.IsSuccessStatusCode) return null;

        var contact = JsonConvert.DeserializeObject<CRMContactResponse>(result.Content!);
        return contact is null ? null : _crmContactResponseMapper.CRMContactResponseToContact(contact);
    }
}