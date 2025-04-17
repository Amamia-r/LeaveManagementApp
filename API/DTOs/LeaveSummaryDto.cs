namespace API.DTOs;

public class LeaveSummaryDto
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public int TotalLeaves { get; set; }
    public int AnnualLeaves { get; set; }
    public int SickLeaves { get; set; }
}
