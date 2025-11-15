using FluentValidation;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator;
using HrManagementSystem.Features.OrganizationManagement.AddOrganization;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest
{
    public class AddRequestRequestViewModel : AssignConfigRequest
    {
        public string Title { get; set; } 

        public string? Description { get; set; }
        public RequestStatus Status { get; set; } 

    }

    public class AddRequestRequestViewModelValiditor : AbstractValidator<AddRequestRequestViewModel>
    {
        public AddRequestRequestViewModelValiditor()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Name Is Requierd");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Name Max Length Is 150 Char");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description Max Length Is 500 Char");
            RuleFor(x => x.Status).IsInEnum().WithMessage("Status Is Not Valid Enum Value");
        }
    }
}
