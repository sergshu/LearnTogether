using FluentValidation;

namespace WebAppAutorization.Models.Validators
{
    public class CreateStudentModelValidator 
        : AbstractValidator<CreateStudentModel>
    {
        public CreateStudentModelValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Enter Name");

            this.RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("Minimal chars - 3");

            this.RuleFor(x => x.Name)
                .Must(x => x.ToUpper().First() == x.First())
                .WithMessage("First must be capital");

            this.RuleFor(x => x.Name).EmailAddress().WithMessage("Wrong email");
        }
    }
}
