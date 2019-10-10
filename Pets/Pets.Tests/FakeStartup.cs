using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pets.Core.Data;
using Pets.Core.Model;
using PetsApi;
using System;

namespace Pets.Tests
{
  public class FakeStartup
  {
    public FakeStartup(IConfiguration configuration)
    {
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<PetsContext>(options =>
      {
        options.UseInMemoryDatabase("DB_TESTE", TestingInMemoryRoot.GetInMemoryDatabaseRootInstance());
      });

      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseMvc();

      var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
      using (var serviceScope = serviceScopeFactory.CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetRequiredService<PetsContext>();

        context.Database.EnsureCreated();

        var pet = new Pet()
        {
          DataEntrada = DateTime.Now,
          Descricao = "Bau Bau",
          Nome = "adadas"
        };
        context.Add(pet);

        context.SaveChanges();
      }
    }
  }
}
