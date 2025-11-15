using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.Command;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest
{
    public class AddRequestEndPoint : BaseEndPoint<AddRequestRequestViewModel, bool>
    {
        public AddRequestEndPoint(EndpointBaseParameters<AddRequestRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<bool>> AddRequest(AddRequestRequestViewModel assignConfig)
        {

            var v = await _mediator.Send(new ConfigurationScopeOrchestrator<RequestScope, Request>(assignConfig.ScopeViewModel, assignConfig.ConfigId));

            if (!v.IsSuccess)
                return EndpointResponse<bool>.Failure(v.Message, v.ErrorCode);

            return EndpointResponse<bool>.Success(true);
        }
    }
}
