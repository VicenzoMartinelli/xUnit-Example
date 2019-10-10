using FluentValidation;
using Pets.Core.Model;
using System;

namespace Pets.Core.Validator
{
  public class PetValidator : AbstractValidator<Pet>
  {
    public PetValidator()
    {
      RuleFor(x => x.Descricao)
        .NotEmpty();

      RuleFor(x => x.DataEntrada)
        .NotEmpty();

      RuleFor(x => x.Nome)
        .NotEmpty();

      RuleFor(x => x.DataEntrada)
        .Must(x => x <= DateTime.Now);
    }
  }
}
