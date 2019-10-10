using FluentAssertions;
using Pets.Core.Model;
using System;
using Xunit;

namespace Pets.Tests.Unit
{
  public class DomainPetUnitTest
  {
    [Theory]
    [InlineData(
      "Bau bau",
      "um cachorro feliz"
    )]
    //[InlineData(
    //  "Bau bau",
    //  null
    //)]
    public void Deveria_Criar_Pet_Com_Dados_Obrigatorios(
        string nome,
        string descricao
      )
    {
      Pet pet = null;
      Action acao = () =>
      {
        pet = new Pet(nome, descricao, string.Empty, DateTime.Now);
      };

      acao.Should().NotThrow<ArgumentException>();

      pet.Nome.Should().BeEquivalentTo(nome);
      pet.Descricao.Should().BeEquivalentTo(descricao);
    }

    [Fact]
    public void Nao_Deveria_Criar_Pet_Sem_Dados_Obrigatorios()
    {
      Pet pet = null;
      Action acao = () =>
      {
        pet = new Pet("", null, string.Empty, DateTime.Now);
      };

      acao.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void Nao_Deveria_Criar_Pet_Com_Data_Entrada_Futura()
    {
      Pet pet = null;
      Action acao = () =>
      {
        pet = new Pet("bau", "bau", "bau", DateTime.Now.AddHours(1));
      };

      acao.Should().ThrowExactly<ArgumentException>();
    }
  }
}
