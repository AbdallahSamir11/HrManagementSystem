using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.Command
{
    public record AddRequestCommand(string Title, RequestStatus Status, string Description, string UserId) : IRequest<RequestResult<bool>>;

    public class AddRequestCommandHandler : RequestHandlerBase<AddRequestCommand, RequestResult<bool>, Request>
    {
        public AddRequestCommandHandler(RequestHandlerBaseParameters<Request> parameters) : base(parameters) { }
        public override async Task<RequestResult<bool>> Handle(AddRequestCommand request, CancellationToken cancellationToken)
        {
            var requestEntity = new Request
            {
                Title = request.Title,
                Status = request.Status,
                Description = request.Description
            };
            await _repository.AddAsync(requestEntity, request.UserId, cancellationToken);
            return RequestResult<bool>.Success(true, "Request created successfully");
        }
    }

}
