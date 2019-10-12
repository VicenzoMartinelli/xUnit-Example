using Pets.Core.Validator;
using System;

namespace Pets.Core.Model
{
  public class BanhoPet
  {
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public Guid PetId { get; set; }
    public decimal Valor { get; set; }
    public virtual Pet Pet { get; set; }

    public BanhoPet()
    {

    }
    public BanhoPet(DateTime data, Guid petId, decimal valor)
    {
      Data = data;
      PetId = petId;
      Valor = valor;

      if (!new BanhoPetValidator().Validate(this).IsValid)
        throw new ArgumentException();
    }
  }
}
