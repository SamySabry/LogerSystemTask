

using BLService.LogerService;
using LoggingSystemTask.Context;
using LoggingSystemTask.Mapper;
using Microsoft.EntityFrameworkCore;
using Reposatries.LogerRepo;

namespace LogerSystemTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<LogContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("LoggerTask")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ILogerRepo, LogerRepo>();
            builder.Services.AddScoped<ILogerService, LogerService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
