using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hris.Recruitment.Api.Services;

namespace Hris.Recruitment.Api.Controllers;

[ApiController]
[Route("api/[controller]")] // Đường dẫn: api/candidates
public class CandidatesController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    // CONSTRUCTOR INJECTION: Tiêm trực tiếp dịch vụ vào Controller qua Hàm khởi tạo
    public CandidatesController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    // API: POST /api/candidates/hire
    [HttpPost("hire")]
    public async Task<IActionResult> HireCandidate([FromBody] HireCandidateRequest request)
    {
        // Kiểm tra dữ liệu đầu vào cơ bản
        if (request.BaseSalary <= 0)
        {
            return BadRequest("Lương cơ bản phải lớn hơn 0!");
        }

        var result = await _candidateService.HireCandidateAsync(request);
        return Ok(result); // Trả về HTTP Status 200 OK kèm kết quả
    }
}