namespace SampleMvc.Web.Validators
{
    using FluentValidation;
    using FluentValidation.Mvc.MetadataExtensions;
    using SampleMvc.Web.Models;

    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");
        }
    }
}