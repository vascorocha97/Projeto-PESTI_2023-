namespace PESTI_MinimalAPIs.Contracts.Incidents;

public class CRMIncidentResponse
{
    public Guid? incidentid	 { get; set; }
    public string title { get; set; } = string.Empty;
    public Guid _subjectid_value { get; set; }
    public Guid _customerid_value { get; set; }
    public int caseorigincode { get; set; }
    public Guid _primarycontactid_value { get; set; }
    public int customersatisfactioncode { get; set; }
}