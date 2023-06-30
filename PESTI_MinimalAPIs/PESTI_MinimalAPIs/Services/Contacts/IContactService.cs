using PESTI_MinimalAPIs.Contracts.Contacts;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Services.Contacts;

public interface IContactService
{
    public Task<Contact?> CreateContact(CRMContact crmContact);
    public Task<Contact?> GetContactById(CRMContactId crmContactId);
    public Task<Contact?> UpdateContact(CRMUpdateContactRequest crmUpdateContactRequest);
    public Task<bool> DeleteContact(CRMDeleteContactId crmContactId);

    public Task<List<Contact>?> GetAllContacts();
}