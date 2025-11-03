namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public record BranchesDto(string Name,
        string? Phone,
        string CityId,
        List<DepartmentsDto> Departments);
}
