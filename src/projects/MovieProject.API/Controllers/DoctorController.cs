using HospitalProject.Model.Dtos.Doctors;
using HospitalProject.Service.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpPost("add")]
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> AddDoctor(DoctorAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        var result = await _doctorService.AddAsync(dto, cancellationToken);
        return Ok(result);
    }

    [HttpGet("getall")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllDoctors(CancellationToken cancellationToken = default)
    {
        var doctors = await _doctorService.GetAllAsync(cancellationToken);
        return Ok(doctors);
    }
    [HttpPut("update")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateDoctor(DoctorUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        var result = await _doctorService.UpdateAsync(dto, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteDoctor(int id, CancellationToken cancellationToken = default)
    {
        var result = await _doctorService.DeleteAsync(id, cancellationToken);
        return Ok(result);
    }
}
