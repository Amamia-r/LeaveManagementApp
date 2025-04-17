using API.Models;

namespace API.DTOs;

public class LeaveRequestFilterDto
{
    public int? EmployeeId { get; set; }
    public LeaveType? LeaveType { get; set; }
    public LeaveStatus? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Keyword { get; set; }

    // Pagination
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    // Sorting
    public string? SortBy { get; set; } = "CreatedAt"; // default sort
    public string? SortOrder { get; set; } = "asc";    // "asc" or "desc"
}

