
using Microsoft.EntityFrameworkCore;

namespace Teknosib.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Teknosib.DataAccess.EntitiyFramework.MyContext>(op=>op.UseSqlServer(connectionstring));



            builder.Services.AddControllers();
            
            builder.Services.AddOpenApi();

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
