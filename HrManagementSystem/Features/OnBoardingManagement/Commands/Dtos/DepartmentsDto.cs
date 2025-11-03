namespace HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos
{
    public class DepartmentsDto(
        string Name,
        string? Description,
        List<TeamsDto> Teams);
}
