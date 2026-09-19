using System;
using System.Runtime.CompilerServices;
namespace Hris.Shared.Contracts;
public record CandidateHiredEvent(
    Guid CandidateId,
    string FullName,
    string Email,
    string PositionApplied,
    string BranchCode,
    decimal Salary,
    DateTime ExpectedStartDate
);