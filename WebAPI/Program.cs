
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            #region swagger settings

            //builder.Services.AddSwaggerGen(opt =>
            //{
            //    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            //    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        In = ParameterLocation.Header,
            //        Description = "Please enter token",
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.Http,
            //        BearerFormat = "JWT",
            //        Scheme = "bearer"
            //    });

            //    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type=ReferenceType.SecurityScheme,
            //                    Id="Bearer"
            //                }
            //            },
            //            new string[]{}
            //        }
            //    });
            //});


            #endregion

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // Ýzin verilen kaynaklar
                        .AllowAnyHeader()                  // Herhangi bir baþlýða izin ver
                        .AllowAnyMethod()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowCredentials();// Herhangi bir HTTP metoduna izin ver
                });
            });

            builder.Services.AddControllers();





            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

                    };
                });

            builder.Services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                });



            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.ConfigureCustomExceptionMiddleware();



            app.UseHttpsRedirection();

            app.UseCors("AllowSpecificOrigins");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
