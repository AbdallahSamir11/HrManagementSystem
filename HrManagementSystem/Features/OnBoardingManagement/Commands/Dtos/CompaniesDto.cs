namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public record CompaniesDto(string Name,
        string? Email,
        string CountryId,
        List<BranchesDto> Branches);
}
