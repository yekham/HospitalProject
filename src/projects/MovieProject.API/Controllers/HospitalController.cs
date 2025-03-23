using HospitalProject.Model.Dtos.Hospitals;
using HospitalProject.Service.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HospitalController : ControllerBase
{
    private readonly IHospitalService _hospitalService;

    public HospitalController(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    [HttpPost("Add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(HospitalAddRequestDto dto)
    {
        var result = await _hospitalService.AddAsync(dto);
        return Ok(result);
    }
    [HttpPut("update")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(HospitalUpdateRequestDto dto)
    {
        await _hospitalService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _hospitalService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _hospitalService.GetAllAsync();
        return Ok(result);
    }
}
