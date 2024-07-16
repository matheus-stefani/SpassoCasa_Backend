
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpassoCasa_Backend.Context;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SpassoCasa_Backend.Model.JWT;
using SpassoCasa_Backend.Jwt;
namespace SpassoCasa_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddIdentity<ApplicationUser,IdentityRole>().
                AddEntityFrameworkStores<ApiDbContext>()
                .AddDefaultTokenProviders();

            var secretKey = builder.Configuration["JWT:SecretKey"]
                                    ?? throw new ArgumentException("Invalid secret key!!");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))


                };
            });
            //builder.Services.AddAuthorization();
            //builder.Services.AddAuthentication("Bearer").AddJwtBearer();

            string myConn = builder.Configuration.GetConnectionString("DefaultConnetion");

            builder.Services.AddDbContext<ApiDbContext>((options) =>
            {
                options.UseMySql(myConn, ServerVersion.AutoDetect(myConn));
            });


            var OrigensComAcessoPermitido = "_origensComAcessoPermitido";

            builder.Services.AddCors(options =>
               options.AddPolicy(name: OrigensComAcessoPermitido,
               policy =>
               {
                   policy.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
               })
            );

            builder.Services.AddScoped<ITokenService, TokenService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseRouting();

            app.UseCors(OrigensComAcessoPermitido);
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
