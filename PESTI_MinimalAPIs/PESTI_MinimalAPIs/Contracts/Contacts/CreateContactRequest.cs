namespace PESTI_MinimalAPIs.Contracts.Contacts;

public class CreateContactRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public Guid AccountId { get; set; } 
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}