using FluentValidation;
using Pets.Core.Model;
using System;

namespace Pets.Core.Validator
{
  public class BanhoPetValidator : AbstractValidator<BanhoPet>
  {
    public BanhoPetValidator()
    {
      RuleFor(x => x.Data)
        .Must(x => x >= DateTime.Now);

      RuleFor(x => x.Valor)
        .GreaterThanOrEqualTo(new decimal(0.1));

      RuleFor(x => x.PetId)
        .NotEmpty();
    }
  }
}
