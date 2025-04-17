using API.DTOs;
using API.Models;

namespace API.Interfaces;

public interface ILeaveRequestRepository
{
    Task<IEnumerable<LeaveRequest>> GetAllAsync();
    Task<LeaveRequest?> GetByIdAsync(int id);
    Task<LeaveRequest> AddAsync(LeaveRequest request);

    Task<bool> UpdateAsync(LeaveRequest request);
    Task<bool> DeleteAsync(int id);

    Task<bool> ExistsAsync(int id);
    Task SaveChangesAsync();

    Task<List<LeaveRequest>> GetFilteredAsync(LeaveRequestFilterDto filter);
    Task<bool> EmployeeHasOverlappingLeave(int employeeId, DateTime start, DateTime end);
    Task<double> GetAnnualLeaveDaysUsed(int employeeId, int year);

    Task<IEnumerable<LeaveSummaryDto>> GetLeaveSummaryAsync(
        int year, string? department = null, DateTime? startDate = null, DateTime? endDate = null
    );


}

