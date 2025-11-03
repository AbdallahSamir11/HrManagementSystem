using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using MediatR;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;

namespace HrManagementSystem.Features.OnBoardingManagement.Orchestrator
{
    public record OnBoardingOrchestrator(OnBoardingDto OnBoardingDto) : IRequest<RequestResult<bool>>;

    public class OnBoardingOrchestratorHandler : RequestHandlerBase<OnBoardingOrchestrator, RequestResult<bool>, Organization>
    {
        public OnBoardingOrchestratorHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }

        public override Task<RequestResult<bool>> Handle(OnBoardingOrchestrator request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
