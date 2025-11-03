namespace HrManagementSystem.Features.OnBoardingManagement
{
    public class OnBoardingRequestViewModel(OrganizationRequestViewModel Organization);

    public record OrganizationRequestViewModel(
            string Name , 
            List<CompanyRequestViewModel> Compaines
      );

    public record CompanyRequestViewModel(
        string Name,
        string? Email,
        string CountryId,
        List<BranchRequestViewModel> Branches
    );

    public record BranchRequestViewModel(
        string Name,
        string? Phone,
        string CityId,
        List<DepartmentRequestViewModel> Departments
    );

    public record DepartmentRequestViewModel(
        string Name,
        string? Description,
        List<TeamRequestViewModel> Teams
    );

    public record TeamRequestViewModel(string Name);
}

