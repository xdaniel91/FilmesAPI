using FilmesApi.Interfaces;
using FilmesApi.Repositorios;
using FilmesApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.Extensions.Hosting;
using FilmesApi.Authorization;
using Microsoft.AspNetCore.Authorization;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<FilmesApi.Data.FilmeContext.ApplicationContext>((DbContextOptionsBuilder options) => options
                .UseLazyLoadingProxies()
                .UseNpgsql(Configuration
                .GetConnectionString("FilmeConnection")));

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
                   .AddJwtBearer(token =>
                   {
                       token.RequireHttpsMetadata = false;
                       token.SaveToken = true;
                       token.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuerSigningKey = true,
                           IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes("clMAY6M6a7e3MDmW79RB")),
                           ValidateIssuer = false,
                           ValidateAudience = false,
                           ClockSkew = TimeSpan.Zero
                       };
                   });

        services.AddAuthorization(options => options.AddPolicy("IdadeMinima", policy => policy.Requirements.Add(new IdadeMinimaRequirement(18))));
        services.AddSingleton<IAuthorizationHandler, IdadeMinimaHandler>();

        services.AddScoped<IFilmeRepository, FilmeRepository>();
        services.AddScoped<IFilmeService, FilmeService>();
        services.AddScoped<ICinemaRepository, CinemaRepository>();
        services.AddScoped<ICinemaService, CinemaService>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        services.AddScoped<IEnderecoService, EnderecoService>();
        services.AddScoped<IGerenteRepository, GerenteRepository>();
        services.AddScoped<IGerenteService, GerenteService>();
        services.AddScoped<ISessaoRepository, SessaoRepository>();
        services.AddScoped<ISessaoService, SessaoService>();

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();




        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}

