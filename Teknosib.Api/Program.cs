
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Teknosib.Business.Mapper;
using Teknosib.Business.Mapper.Register;
using Teknosib.Business;
using Teknosib.Business.Services;
using Teknosib.Business.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation.AspNetCore;
using FluentValidation;


namespace Teknosib.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Teknosib.DataAccess.EntitiyFramework.MyContext>(op => op.UseSqlServer(connectionstring));
            builder.Services.AddAutoMapper(typeof(AuthService).Assembly);
            //Business Layer /Service
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            //DataAccess Layer
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         // Token'ý kimin oluþturduðunu doðrula (Issuer)
                         ValidateIssuer = true,
                         // Token'ýn hangi kitle için olduðunu doðrula (Audience)
                         ValidateAudience = true,
                         // Token'ýn ömrünü kontrol et
                         ValidateLifetime = true,
                         // Token'ý imzalayan anahtarýn doðruluðunu kontrol et
                         ValidateIssuerSigningKey = true,
                         // Geçerli Issuer ve Audience deðerlerini appsettings'den al
                         ValidIssuer = builder.Configuration["Jwt:Issuer"],
                         ValidAudience = builder.Configuration["Jwt:Audience"],
                         // Ýmzalama anahtarýný appsettings'den al ve ayarla
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
                     };
                 });
            // FluentValidation'ý ve validator'larý projeye ekliyoruz.
            builder.Services.AddFluentValidationAutoValidation();
            object value = builder.Services.AddValidatorsFromAssembly(typeof(AuthService).Assembly);


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // Genel Swagger doküman tanýmý
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Teknosib API", Version = "v1" });

                // JWT için bir güvenlik þemasý (Bearer token) tanýmlýyoruz.
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Lütfen Bearer'dan sonra bir boþluk býrakarak token'ý girin.",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Tanýmladýðýmýz güvenlik þemasýný, token gerektiren tüm endpoint'lere uygula.
                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                     {
                         new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                         {
                              Reference = new Microsoft.OpenApi.Models.OpenApiReference
                                {
                                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                         },
                        new List<string>()
                     }
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });



            var app = builder.Build();

            app.UseCors("AllowAll");
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

