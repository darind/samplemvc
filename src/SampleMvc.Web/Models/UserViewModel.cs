namespace SampleMvc.Web.Models
{
    using System.ComponentModel;
    using FluentValidation.Attributes;
    using SampleMvc.Web.Validators;

    [Validator(typeof(UserViewModelValidator))]
    public class UserViewModel
    {
        public int Id { get; set; }

        [DisplayName("First name *")]
        public string FirstName { get; set; }

        [DisplayName("Last name *")]
        public string LastName { get; set; }

        public int? Age { get; set; }
    }
}