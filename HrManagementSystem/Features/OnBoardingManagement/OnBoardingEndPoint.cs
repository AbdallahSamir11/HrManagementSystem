using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.OnBoardingManagement
{
    public class OnBoardingEndPoint : BaseEndPoint<OnBoardingRequestViewModel, bool>
    {
        public OnBoardingEndPoint(EndpointBaseParameters<OnBoardingRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<bool>> OnBoarding(OnBoardingRequestViewModel request)
        {

            return EndpointResponse<bool>.Success(true);
        }
    }
}
