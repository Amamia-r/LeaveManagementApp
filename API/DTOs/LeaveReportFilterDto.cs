namespace API.DTOs;

public class LeaveReportFilterDto
{
    public int Year { get; set; }
    public string? Department { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
