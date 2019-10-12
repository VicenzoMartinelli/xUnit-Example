using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pets.Core.Data;

namespace PetsApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<PetsContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("PetsDb")));

      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseCors((x) =>
      {
        x.AllowAnyOrigin();
        x.AllowAnyMethod();
        x.AllowAnyHeader();
      });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
    }
  }
}
