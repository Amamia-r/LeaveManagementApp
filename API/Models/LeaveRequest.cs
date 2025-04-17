using System;

namespace API.Models;

public class LeaveRequest
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public LeaveType LeaveType { get; set; }  // Uses enum
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveStatus Status { get; set; } = LeaveStatus.Pending;  // Uses enum
    public string? Reason { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Employee Employee { get; set; } = null!;
}

public enum LeaveType { Annual, Sick, Other }
public enum LeaveStatus { Pending, Approved, Rejected }
