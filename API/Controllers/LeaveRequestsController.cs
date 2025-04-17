using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class LeaveRequestsController : ControllerBase
{
    private readonly ILeaveRequestService _service;
    private readonly IMapper _mapper;

    public LeaveRequestsController(ILeaveRequestService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetAll()
    {
        var requests = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<LeaveRequestDto>>(requests));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto>> Get(int id)
    {
        var request = await _service.GetByIdAsync(id);
        if (request == null) return NotFound();

        return Ok(_mapper.Map<LeaveRequestDto>(request));
    }

    [HttpPost]
    public async Task<ActionResult<LeaveRequestDto>> Create(LeaveRequestCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, LeaveRequestDto dto)
    {
        if (id != dto.Id) return BadRequest();

        var updated = await _service.UpdateAsync(dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }


    //  Filter
    [HttpPost("filter")]
    public async Task<IActionResult> Filter([FromBody] LeaveRequestFilterDto filter)
    {
        var results = await _service.GetFilteredAsync(filter);
        return Ok(results);
    }

    // Reporting
    [HttpPost("report")]
    public async Task<IActionResult> GetSummary([FromBody] LeaveReportFilterDto report)
    {
        var summary = await _service.GetLeaveSummaryAsync
        (report.Year, report.Department, report.StartDate, report.EndDate);

        return Ok(summary);
    }

    // Approval 
    [HttpPost("{id}/approve")]
    public async Task<IActionResult> Approve(int id)
    {
        var request = await _service.GetByIdAsync(id);

        if (request == null) return NotFound();

        // Check if the status is "Pending", otherwise return BadRequest
        if (request.Status != LeaveStatus.Pending)
            return BadRequest("Only pending request can be approved.");

        request.Status = LeaveStatus.Approved;

        var update = await _service.UpdateAsync(request);

        // If updated successfully, return NoContent, otherwise NotFound
        return update ? NoContent() : NotFound();
    }

}




