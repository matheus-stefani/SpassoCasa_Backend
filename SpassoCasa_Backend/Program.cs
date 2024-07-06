
using Microsoft.EntityFrameworkCore;
using SpassoCasa_Backend.Context;

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
