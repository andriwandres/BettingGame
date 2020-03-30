using AutoMapper;
using BettingGame.Core;
using BettingGame.Core.Options;
using BettingGame.Core.Services;
using BettingGame.Data;
using BettingGame.Data.Database;
using BettingGame.Service;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BettingGame.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public IWebHostEnvironment Environment { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BettingGameContext>(builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), options =>
                {
                    options.MigrationsAssembly("BettingGame.Data");
                });
            });

            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            var jwtSection = Configuration.GetSection("JsonWebToken");
            var jwtSettings = jwtSection.Get<JwtOptions>();
            var jwtSecret = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            var corsSection = Configuration.GetSection("CrossOriginResourceSharing");

            // Add Options
            services.Configure<JwtOptions>(jwtSection);
            services.Configure<CorsOptions>(corsSection);

            services.AddAuthentication(builder =>
            {
                builder.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                builder.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(builder =>
            {
                builder.RequireHttpsMetadata = false;
                builder.SaveToken = true;
                builder.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtSecret),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            // Add SignalR Websocket
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = Environment.IsDevelopment();
            });

            // Add Swagger
            services.AddSwaggerGen(options =>
            {
                // Swagger Document
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Betting Game Web API",
                    Description = "REST API for exchanging betting game related data for the European Championship 2021",
                });

                // Add Bearer Security Definition
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                // Add Bearer Security Requirement
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] { }
                    }
                });

                // Add XML Documentation
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            // Add Http Context Accessor
            services.AddHttpContextAccessor();

            // Add Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add Service Layer Dependencies
            services.AddTransient<ICryptoService, CryptoService>();
            services.AddTransient<IAuthService, AuthService>();

            // Add Cross-Origin-Resource-Sharing
            services.AddCors();

            // Add Support for controllers
            services.AddControllers()

                // Add FluentValidation
                .AddFluentValidation(configuration =>
                {
                    configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IOptions<CorsOptions> corsOptions)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            // Use Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Betting Game Web API");
                options.DocExpansion(DocExpansion.List);
            });

            // Use Routing
            app.UseRouting();

            CorsOptions cors = corsOptions.Value;

            // Use Cross-Origin-Resource-Sharing
            app.UseCors(builder =>
            {
                builder.WithOrigins(cors.AllowedOrigins);
                builder.WithMethods(cors.AllowedMethods);
                builder.WithHeaders(cors.AllowedHeaders);
            });

            // Use Authorization
            app.UseAuthorization();

            // Map Controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
