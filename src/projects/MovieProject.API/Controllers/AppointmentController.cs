using HospitalProject.Model.Dtos.Appointments;
using HospitalProject.Service.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    [HttpPost("add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(AppointmentAddRequestDto dto)
    {
        var result = await _appointmentService.AddAsync(dto);
        return Ok(result);
    }
    [HttpPut("update")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(AppointmentUpdateRequestDto dto)
    {
        await _appointmentService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> Delete(int id)
    {
        await _appointmentService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("getall")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _appointmentService.GetAllAsync();
        return Ok(result);
    }
}
