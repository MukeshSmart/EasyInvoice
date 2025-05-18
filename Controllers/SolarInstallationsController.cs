using InvoicingAPI.Models;
using InvoicingAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SolarInstallationsController : ControllerBase
{
    private readonly ISolarInstallationRepository _repository;

    public SolarInstallationsController(ISolarInstallationRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpPatch("{id}/stage")]
    public async Task<IActionResult> UpdateStage(int id, [FromBody] UpdateInstallationStageDto dto)
    {
        var installation = await _repository.GetByIdAsync(id);
        if (installation == null) return NotFound();

        installation.Stage = dto.Stage;

        if (dto.Stage == InstallationStage.ExecutiveApproved || dto.Stage == InstallationStage.ExecutiveRejected)
        {
            installation.ExecutiveComments = dto.Comments;
            installation.ExecutiveReviewDate = DateTime.UtcNow;
        }
        else if (dto.Stage == InstallationStage.CompanyApproved || dto.Stage == InstallationStage.CompanyRejected)
        {
            installation.CompanyComments = dto.Comments;
            installation.CompanyReviewDate = DateTime.UtcNow;
        }

        await _repository.UpdateAsync(installation);
        return NoContent();
    }
}

// DTO for stage update
public class UpdateInstallationStageDto
{
    public InstallationStage Stage { get; set; }
    public string? Comments { get; set; }
}