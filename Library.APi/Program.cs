
using LibraryApi.Data.Entities;
using LibraryApi.Data.Mappers;
using LibraryApi.Service.Implementations;
using LibraryApi.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.APi
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
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
            });
            builder.Services.AddScoped<IGenreRepository, GenreService>();
            builder.Services.AddScoped<IAuthorRepository, AuthorService>();
            builder.Services.AddScoped<IBookRepository,BookService >();
            builder.Services.AddAutoMapper(typeof(MapProfile));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
