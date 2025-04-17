using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeaveRequest>()
            .Property(lr => lr.LeaveType)
            .HasConversion<string>();

        modelBuilder.Entity<LeaveRequest>()
            .Property(lr => lr.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, FullName = "Harry Potter", Department = "IT", JoiningDate = new DateTime(2020, 1, 10) },
            new Employee { Id = 2, FullName = "Hermione Granger", Department = "HR", JoiningDate = new DateTime(2021, 6, 15) },
            new Employee { Id = 3, FullName = "Ron Weasley", Department = "Finance", JoiningDate = new DateTime(2019, 3, 22) }
        );

        modelBuilder.Entity<LeaveRequest>().HasData(

    // Harry (Annual Leave - total 10 days)
    new LeaveRequest { Id = 1, EmployeeId = 1, LeaveType = LeaveType.Annual, StartDate = new DateTime(2024, 07, 01), EndDate = new DateTime(2024, 07, 05), Status = LeaveStatus.Approved, Reason = "Vacation", CreatedAt = DateTime.Now },
    new LeaveRequest { Id = 2, EmployeeId = 1, LeaveType = LeaveType.Annual, StartDate = new DateTime(2024, 08, 01), EndDate = new DateTime(2024, 08, 06), Status = LeaveStatus.Pending, Reason = "Family trip", CreatedAt = DateTime.Now },

    // Hermione (Sick Leave with reason)
    new LeaveRequest { Id = 3, EmployeeId = 2, LeaveType = LeaveType.Sick, StartDate = new DateTime(2024, 06, 10), EndDate = new DateTime(2024, 06, 12), Status = LeaveStatus.Approved, Reason = "Flu symptoms", CreatedAt = DateTime.Now },

    // Hermione (Other type, testing keyword search)
    new LeaveRequest { Id = 4, EmployeeId = 2, LeaveType = LeaveType.Other, StartDate = new DateTime(2024, 09, 05), EndDate = new DateTime(2024, 09, 06), Status = LeaveStatus.Rejected, Reason = "Personal business trip", CreatedAt = DateTime.Now },

    // Ron (Annual - 20 days already used)
    new LeaveRequest { Id = 5, EmployeeId = 3, LeaveType = LeaveType.Annual, StartDate = new DateTime(2024, 05, 01), EndDate = new DateTime(2024, 05, 11), Status = LeaveStatus.Approved, Reason = "Europe trip", CreatedAt = DateTime.Now },
    new LeaveRequest { Id = 6, EmployeeId = 3, LeaveType = LeaveType.Annual, StartDate = new DateTime(2024, 06, 01), EndDate = new DateTime(2024, 06, 10), Status = LeaveStatus.Approved, Reason = "Staycation", CreatedAt = DateTime.Now },

    // Ron (Sick Leave with no reason – will break the rule)
    new LeaveRequest { Id = 7, EmployeeId = 3, LeaveType = LeaveType.Sick, StartDate = new DateTime(2024, 07, 20), EndDate = new DateTime(2024, 07, 22), Status = LeaveStatus.Pending, Reason = "", CreatedAt = DateTime.Now }
        );

    }

}
