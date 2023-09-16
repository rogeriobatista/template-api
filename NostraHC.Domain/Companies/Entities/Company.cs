using FluentValidation;
using NostraHC.Domain.Companies.Enums;
using NostraHC.Shared.Domain;

namespace NostraHC.Domain.Companies.Entities
{
    public class Company : Entity<long, Company>
    {
        public string Name { get; set; }
        public CompanyStatus Status { get; set; }

        public Company()
        {
            Status = CompanyStatus.Active;
        }

        public override bool Validate()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Status)
                .IsInEnum();


            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
