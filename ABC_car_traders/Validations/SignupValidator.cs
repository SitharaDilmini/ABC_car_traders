using ABC_car_traders.Models;
using FluentValidation;

namespace ABC_car_traders.Validations
{
    public class SignupValidator : AbstractValidator<UserInputModel>
    {
        public SignupValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please enter your name.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please enter your email.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Please enter your address.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Please enter your phone number.")
                .Matches(@"^\d{10}$").WithMessage("Phone number is not valid. Please enter a 10-digit phone number.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Please enter a password.");

            RuleFor(x => x.PasswordConfirm)
                .Equal(x => x.Password).WithMessage("Passwords do not match. Please try again.");
        }
    }
}
