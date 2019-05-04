using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Serilog;
using Autofac;
using AppDiarista.IOC;
using AppDiarista.Common.ExtensionMethods;
using AppDiarista.API.Middlewares;
using AppDiarista.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using System;

namespace AppDiarista.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            // Setar o Assembly de um Mapper para resolver para todos         
            services.AddAutoMapper(typeof(Mapping.Profiles.IntencaoProfile).GetTypeInfo().Assembly);

            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthorizeFilter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddOptions();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey (System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("JwtConfiguration:Secret").Value)),
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidIssuer = configuration.GetSection("JwtConfiguration:Issuer").Value,
                    ValidAudience = configuration.GetSection("JwtConfiguration:Audience").Value
        }
            );

            ConfigureLogging(configuration);
            
            ConfigurarConnectionStrings(services);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new IocService(configuration));
        }

        public void ConfigureLogging(IConfiguration configuration)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        }

        private void ConfigurarConnectionStrings(IServiceCollection services)
        {
            string appDiaristaDBConnectionString = configuration.GetSection("ConnectionStrings:AppDiaristaDB").Value;

            services.AddDbContext<AppDiaristaContext>(options => options.UseSqlServer(appDiaristaDBConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Inicializar o Container de IoC na classe estática;
            IoCExtension.Instance = app.ApplicationServices;

            loggerFactory.AddSerilog();

            // Tratamento Globais de erros
            app.UseErrorLogging();

            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
