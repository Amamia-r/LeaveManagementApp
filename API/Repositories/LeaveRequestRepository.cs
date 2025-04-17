using System.Linq.Dynamic.Core;
using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class LeaveRequestRepository : ILeaveRequestRepository
{
    private readonly AppDbContext _context;
    public LeaveRequestRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
    {
        return await _context.LeaveRequests
            .Include(l => l.Employee)
            .ToListAsync();
    }

    public async Task<LeaveRequest?> GetByIdAsync(int id)
    {
        return await _context.LeaveRequests
            .Include(l => l.Employee)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<LeaveRequest> AddAsync(LeaveRequest request)
    {
        _context.LeaveRequests.Add(request);
        await _context.SaveChangesAsync();
        return request;
    }

    public async Task<bool> UpdateAsync(LeaveRequest request)
    {
        var existing = await _context.LeaveRequests.FindAsync(request.Id);
        if (existing == null) return false;

        _context.Entry(existing).CurrentValues.SetValues(request);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var request = await _context.LeaveRequests.FindAsync(id);
        if (request == null) return false;

        _context.LeaveRequests.Remove(request);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.LeaveRequests.AnyAsync(l => l.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }


    //  Filtering - Sorting - Pagination
    public async Task<List<LeaveRequest>> GetFilteredAsync(LeaveRequestFilterDto filter)
    {
        var query = _context.LeaveRequests
            .Include(lr => lr.Employee).AsQueryable();

        //Filtering 
        if (filter.EmployeeId.HasValue)
        {
            query = query.Where(l => l.EmployeeId == filter.EmployeeId);
        }
        if (filter.LeaveType.HasValue)
        {
            query = query.Where(l => l.LeaveType == filter.LeaveType);
        }
        if (filter.Status.HasValue)
        {
            query = query.Where(l => l.Status == filter.Status);
        }
        if (filter.StartDate.HasValue)
        {
            query = query.Where(l => l.StartDate == filter.StartDate);
        }
        if (filter.EndDate.HasValue)
        {
            query = query.Where(l => l.EndDate == filter.EndDate);
        }

        if (!string.IsNullOrWhiteSpace(filter.Keyword))
        {
            var keyword = filter.Keyword!;
            query = query.Where(l => l.Reason != null && l.Reason.Contains(keyword!));
        }

        // Sorting
        if (!string.IsNullOrEmpty(filter.SortBy))
        {
            var sortOrder = filter.SortOrder?.ToLower() == "desc" ? "descending" : "ascending";
            query = query.OrderBy($"{filter.SortBy} {sortOrder}");
        }

        //  Pagination
        int skip = (filter.Page - 1) * filter.PageSize;
        query = query.Skip(skip).Take(filter.PageSize);

        return await query.ToListAsync();

    }

    public async Task<bool> EmployeeHasOverlappingLeave(int employeeId, DateTime start, DateTime end)
    {
        return await _context.LeaveRequests.AnyAsync(l =>
        l.EmployeeId == employeeId &&
        l.Status != LeaveStatus.Rejected &&
        l.StartDate <= end &&
        l.EndDate >= start);
    }
    public async Task<double> GetAnnualLeaveDaysUsed(int employeeId, int year)
    {
        var leaves = await _context.LeaveRequests
            .Where(l =>
                l.EmployeeId == employeeId &&
                l.LeaveType == LeaveType.Annual &&
                l.Status == LeaveStatus.Approved &&
                l.StartDate.Year == year)
            .ToListAsync();

        return leaves.Sum(l => (l.EndDate - l.StartDate).TotalDays + 1);
    }

    public async Task<IEnumerable<LeaveSummaryDto>> GetLeaveSummaryAsync(int year, string? department = null, DateTime? startDate = null, DateTime? endDate = null)
    {
        var query = _context.LeaveRequests
        .Include(lr => lr.Employee)
        .AsQueryable();

        query = query.Where(lr =>
        lr.StartDate.Year == year || lr.EndDate.Year == year);

        if (!string.IsNullOrWhiteSpace(department))
        { query = query.Where(lr => lr.Employee.Department == department); }

        if (startDate.HasValue)
        { query = query.Where(lr => lr.StartDate >= startDate.Value); }

        if (endDate.HasValue)
        { query = query.Where(lr => lr.EndDate <= endDate.Value); }

        var summary = await query
        .Where(lr => lr.Employee != null)
        .GroupBy(lr => new { lr.EmployeeId, lr.Employee.FullName, lr.Employee.Department })
        .Select(g => new LeaveSummaryDto
        {
            EmployeeId = g.Key.EmployeeId,
            EmployeeName = g.Key.FullName,
            Department = g.Key.Department,
            TotalLeaves = g.Count(),
            AnnualLeaves = g.Count(x => x.LeaveType == LeaveType.Annual),
            SickLeaves = g.Count(x => x.LeaveType == LeaveType.Sick)

        }).ToListAsync();

        return summary;
    }
}

