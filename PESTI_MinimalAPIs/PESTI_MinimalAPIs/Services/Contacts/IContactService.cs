using PESTI_MinimalAPIs.Dto;

namespace PESTI_MinimalAPIs.Services.Contacts;

public interface IContactService
{
    public Task<ContactDto> CreateContact(ContactDto contact);
}