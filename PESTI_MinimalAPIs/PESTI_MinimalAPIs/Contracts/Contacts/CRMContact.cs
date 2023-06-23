namespace PESTI_MinimalAPIs.Contracts.Contacts;

public class CRMContact
{
    public string myp_ConctactFirstName { get; set; } = string.Empty;
    public string myp_ConctactLastName { get; set; } = string.Empty;
    public string myp_ConctactJobTitle { get; set; } = string.Empty;
    public Guid myp_ContactAccountId { get; set; } 
    public string myp_ContactEmail { get; set; } = string.Empty;
    public string myp_ContactPhone { get; set; } = string.Empty;
}