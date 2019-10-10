using FluentAssertions;
using Pets.Core.Model;
using System;
using Xunit;

namespace Pets.Tests.Unit
{
  public class DomainBanhoPetUnitTest
  {
    public static TheoryData<DateTime> data = new TheoryData<DateTime>
    {
       DateTime.MinValue,
       DateTime.Now.AddHours(-1),
       DateTime.Now.AddHours(-10),
       DateTime.Now.AddDays(-10),
       DateTime.Now.AddMonths(-10),
       DateTime.Now.AddYears(-10),
    };

    [Fact]
    public void Deveria_Criar_BanhoPet_Com_Dados_Obrigatorios()
    {
      BanhoPet banho = null;
      Action acao = () =>
      {
        banho = new BanhoPet(DateTime.Now.AddDays(5), Guid.NewGuid(), new decimal(1));
      };

      acao.Should().NotThrow<ArgumentException>();
    }

    [Fact]
    public void Nao_Deveria_Criar_BanhoPet_Sem_Dados_Obrigatorios()
    {
      BanhoPet banhoPet = null;
      Action acao = () =>
      {
        banhoPet = new BanhoPet(default, default, default);
      };

      acao.Should().ThrowExactly<ArgumentException>();
    }

    [Theory]
    [MemberData(nameof(data))]
    public void Nao_Deveria_Permitir_Criar_BanhoPet_Para_Passado(DateTime data)
    {
      BanhoPet pet = null;
      Action acao = () =>
      {
        pet = new BanhoPet(data, Guid.NewGuid(), new decimal(5));
      };

      acao.Should().Throw<ArgumentException>();
    }
  }
}
