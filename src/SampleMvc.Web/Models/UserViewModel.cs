namespace SampleMvc.Web.Models
{
    using FluentValidation.Attributes;
    using SampleMvc.Web.Validators;

    [Validator(typeof(UserViewModelValidator))]
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
    }
}