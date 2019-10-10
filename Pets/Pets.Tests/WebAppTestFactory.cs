using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pets.Core.Data;
using Pets.Core.Model;
using PetsApi;
using System;

namespace Pets.Tests
{
  public class WebAppTestFactory : WebApplicationFactory<FakeStartup>
  {
    protected override IWebHostBuilder CreateWebHostBuilder()
    {
      return WebHost.CreateDefaultBuilder(null);
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      builder
      .UseStartup<FakeStartup>();
    }
  }
}
