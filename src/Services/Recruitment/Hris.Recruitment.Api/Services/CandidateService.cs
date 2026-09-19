using System;
using System.Threading.Tasks;
using Hris.Shared.Contracts;

namespace Hris.Recruitment.Api.Services;

/* DTO (Data Transfer Object)* : Dữ liệu gửi lên từ người dùng */
public record HireCandidateRequest(
    string FullName,
    string Email,
    string Position,
    string BranchCode,
    decimal BaseSalary,
    DateTime ExpectedStartDate
);
/* DTO : Dữ liệu trả về*/
public record HireCandidateResponse(
    Guid CandidateId,
    string FullName,
    string Status,
    string Message
);
/* Hop đồng trừu tượng hóa*/
public interface ICandidateService
{
    Task<HireCandidateResponse>HireCandidateAsync(HireCandidateRequest request);
}
/* Implementation Nghiệp vụ thực tế*/
public class CandidateService : ICandidateService
{
    public async Task<HireCandidateResponse> HireCandidateAsync (HireCandidateRequest request)
    {
     await Task.Delay(100);
        var candidateId =Guid.NewGuid();
        var hireEvent=new CandidateHiredEvent(
            candidateId,
            request.FullName,
            request.Email,
             request.Position,
            request.BranchCode,
            request.BaseSalary,
            request.ExpectedStartDate
            );
        Console.WriteLine($"[Tuyển Dụng] Đã trúng tuyển: {hireEvent.FullName} - Chi nhánh :{hireEvent.BranchCode}");  
          return new HireCandidateResponse(
            candidateId,
            request.FullName,
            "HIRED",
            $"Ứng viên {request.FullName} đã được tiếp nhận thành công vào chi nhánh {request.BranchCode}!"
        );
    } 
}