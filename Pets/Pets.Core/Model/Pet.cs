using Pets.Core.Validator;
using System;

namespace Pets.Core.Model
{
  public class Pet
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Raca { get; set; }
    public DateTime DataEntrada { get; set; }

    public Pet()
    {

    }
    public Pet(string nome, string descricao, string raca, DateTime dataEntrada)
    {
      Nome = nome;
      Descricao = descricao;
      Raca = raca;
      DataEntrada = dataEntrada;

      if (!new PetValidator().Validate(this).IsValid)
        throw new ArgumentException();
    }
  }
}
