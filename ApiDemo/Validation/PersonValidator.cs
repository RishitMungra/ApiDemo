
using ApiDemo.Models;
using FluentValidation;

namespace APIDemo.Validation
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(PersonModel => PersonModel.Name)
                .NotNull()
                .WithMessage("Name Can't Be Null")
                .NotEmpty()
                .WithMessage("Name Can't Be Empty");

            RuleFor(PersonModel => PersonModel.Email)
                .NotEmpty()
                .WithMessage("Email can't be empty")
                .MaximumLength(100)
                .WithMessage("Email must be less than or equal to 100 characters")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Enter a valid email address");


            RuleFor(PersonModel => PersonModel.Contact)
                .NotEmpty()
                .WithMessage("Contact number can't be empty")
                .Matches(@"^[0-9]{10}$")
                .WithMessage("Enter a valid 10-digit contact number");

        }
    }
}
