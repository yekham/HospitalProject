using HospitalProject.Model.Dtos.Patients;
using HospitalProject.Service.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpPost("Add")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(PatientAddRequestDto dto)
    {
        var result = await _patientService.AddAsync(dto);
        return Ok(result);
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update(PatientUpdateRequestDto dto)
    {
        await _patientService.UpdateAsync(dto);
        return Ok();
    }
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _patientService.DeleteAsync(id);
        return Ok();
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _patientService.GetAllAsync();
        return Ok(result);
    }
}
