using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;

namespace API.Services;

public class LeaveRequestService : ILeaveRequestService
{
    private readonly ILeaveRequestRepository _repo;
    private readonly IMapper _mapper;

    public LeaveRequestService(ILeaveRequestRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<LeaveRequestDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return _mapper.Map<List<LeaveRequestDto>>(list);
    }

    public async Task<LeaveRequestDto?> GetByIdAsync(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item == null ? null : _mapper.Map<LeaveRequestDto>(item);
    }
    public async Task<bool> UpdateAsync(LeaveRequestDto dto)
    {
        var entity = _mapper.Map<LeaveRequest>(dto);
        return await _repo.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repo.DeleteAsync(id);
    }



    public async Task<LeaveRequestDto> CreateAsync(LeaveRequestCreateDto dto)
    {
        // 1. No overlapping leave dates
        var hasOverlap = await _repo.EmployeeHasOverlappingLeave(
            dto.EmployeeId, dto.StartDate, dto.EndDate);

        if (hasOverlap)
            throw new Exception("Employee already has a leave during this period.");

        // 2. Annual leave: max 20 days per year
        if (dto.LeaveType == LeaveType.Annual)
        {
            var totalDays = (dto.EndDate - dto.StartDate).TotalDays + 1;

            var annualUsed = await _repo.GetAnnualLeaveDaysUsed(
                dto.EmployeeId, dto.StartDate.Year);

            if (annualUsed + totalDays > 20)
                throw new Exception("Exceeds max 20 annual leave days for the year.");
        }

        // 3. Sick leave requires reason
        if (dto.LeaveType == LeaveType.Sick && string.IsNullOrWhiteSpace(dto.Reason))
            throw new Exception("Sick leave requires a reason.");

        //  SAVE

        var entity = _mapper.Map<LeaveRequest>(dto);
        await _repo.AddAsync(entity);
        await _repo.SaveChangesAsync();

        return _mapper.Map<LeaveRequestDto>(entity);
    }


    public async Task<List<LeaveRequestDto>> GetFilteredAsync(LeaveRequestFilterDto filterDto)
    {
        var filtered = await _repo.GetFilteredAsync(filterDto);
        return _mapper.Map<List<LeaveRequestDto>>(filtered);
    }

    public async Task<IEnumerable<LeaveSummaryDto>> GetLeaveSummaryAsync(
        int year, string? department = null, DateTime? startDate = null, DateTime? endDate = null)
    {
        return await _repo.GetLeaveSummaryAsync(year, department, startDate, endDate);
    }
}

