using API.DTOs;

namespace API.Interfaces;

public interface ILeaveRequestService
{
    Task<List<LeaveRequestDto>> GetAllAsync();
    Task<LeaveRequestDto?> GetByIdAsync(int id);
    Task<LeaveRequestDto> CreateAsync(LeaveRequestCreateDto dto);
    
    Task<bool> UpdateAsync(LeaveRequestDto dto);
    Task<bool> DeleteAsync(int id);

    Task<List<LeaveRequestDto>> GetFilteredAsync(LeaveRequestFilterDto filterDto);

    Task<IEnumerable<LeaveSummaryDto>> GetLeaveSummaryAsync(
        int year, string? department = null, DateTime? startDate = null, DateTime? endDate = null
    );

}

