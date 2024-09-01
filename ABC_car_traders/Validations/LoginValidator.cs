using ABC_car_traders.Models;
using FluentValidation;


namespace ABC_car_traders.Validations
{
    public class LoginValidator : AbstractValidator<UserInputModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Please enter your username or email.");

        }
    }
}
