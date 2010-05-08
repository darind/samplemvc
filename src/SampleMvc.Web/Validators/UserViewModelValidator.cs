using SampleMvc.Web.Models;
using FluentValidation;

namespace SampleMvc.Web.Validators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithPropertyName("First name")
                .WithMessage("First name is required");
        }
    }
}