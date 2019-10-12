using Pets.Core.Validator;
using System;
using System.Collections.ObjectModel;

namespace Pets.Core.Model
{
  public class Pet
  {
    public Guid Id { get; internal set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Raca { get; set; }
    public DateTime DataEntrada { get; internal set; }

    public Collection<BanhoPet> Banhos { get; set; }
    public Pet()
    {
      DataEntrada = DateTime.Now;
    }
    public Pet SetId(Guid id)
    {
      this.Id = id;
      return this;
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
