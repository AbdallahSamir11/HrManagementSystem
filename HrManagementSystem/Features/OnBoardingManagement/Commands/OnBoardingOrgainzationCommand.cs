using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingOrgainzationCommand() : IRequest<RequestResult<bool>>;

}
