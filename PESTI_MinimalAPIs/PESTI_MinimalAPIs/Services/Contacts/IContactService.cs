using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Contracts.Contacts;

namespace PESTI_MinimalAPIs.Services.Contacts;

public interface IContactService
{
    public Task<ContactDto> CreateContact(ContactDto contact);
}