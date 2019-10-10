using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Pets.Core.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Pets.Tests.Integration
{
  public class PetEndPointsTest : IClassFixture<WebAppTestFactory>
  {
    protected readonly WebAppTestFactory _factory;
    protected readonly HttpClient _client;

    public PetEndPointsTest(WebAppTestFactory factory)
    {
      _factory = factory;

      _client = factory.CreateClient(new WebApplicationFactoryClientOptions
      {
        AllowAutoRedirect = false,
        BaseAddress = new Uri("http://localhost:5000"),
      });

      _client.DefaultRequestHeaders
          .Accept
          .Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    [Fact]
    public async Task Deveria_Obter_Um_Registro_Da_Base_De_Dados()
    {
      var response = await _client.GetAsync($"pets");

      response.EnsureSuccessStatusCode();

      // Asserts
      response.StatusCode.Should().Be(HttpStatusCode.OK);

      Func<Task> act = async () => {
        var r = await response.Content.ReadAsStringAsync();

        var lst = JsonConvert.DeserializeObject<List<Pet>>(r);

        lst.Should().NotBeNullOrEmpty().And.HaveCount(1);
      };

      await act.Should().NotThrowAsync<Exception>();
    }
  }

}
