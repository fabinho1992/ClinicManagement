using ClinicManagement.Application.Commands.DoctorCommands.CreateDoctor;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.FluentValidation.DoctorValidations
{
    public class CreateDoctorValidation : AbstractValidator<CreateDocCommand>
    {
        public CreateDoctorValidation()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull()
               .WithMessage("Name cannot be null")
               .MaximumLength(50).WithMessage("Must contain a maximum of 50 characters")
               .MinimumLength(3).WithMessage("Must contain a minimum of 3 characters");

            RuleFor(p => p.Cpf).NotEmpty().NotNull()
                .WithMessage("Cpf cannot be null")
                .MaximumLength(14).WithMessage("Must contain a maximum of 14 characters");

            RuleFor(d => d.Email).NotNull()
                .WithMessage("Email cannot be null")
                .EmailAddress().WithMessage("Insert a email valid ");

            RuleFor(d => d.DateOfBirth).NotNull()
                .WithMessage("DateOfBirth cannot be null")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Date of birth must be less than or equal to the current date.");

            RuleFor(p => p.Phone).NotEmpty().NotNull()
                .MinimumLength(10).WithMessage("Must contain a maximum of 10 characters")
                .MaximumLength(15).WithMessage("Must contain a maximum of 15 characters");


            RuleFor(d => d.BloodType).NotNull()
                .WithMessage("BloodType cannot be null")
                .IsInEnum().WithMessage("0 - A / 1 - B / 2 - AB / 3 - O");

            RuleFor(d => d.ZipCode).NotEmpty().NotNull()
               .WithMessage("ZipCode cannot be null")
               .MaximumLength(8).WithMessage("Must contain a maximum of 8 characters");

            RuleFor(d => d.Complement).NotNull().NotEmpty()
                .WithMessage("Complement cannot be null")
                .MaximumLength(50).WithMessage("Must contain a maximum of 50 characteres");

        }
    }
}
