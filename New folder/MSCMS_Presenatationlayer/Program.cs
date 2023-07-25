using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MSCMS_BackEnd.Data;
using MSCMS_BusinessLayer.Interface;
using MSCMS_BusinessLayer.Services;
using MSCMS_Datalayer.DTO;
using MSCMS_Datalayer.Entities;
using MSCMS_DataLayer.Helpers;
using Serilog;
using System.Diagnostics;

namespace MSCMS_Presentationlayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var policyName = "MyAllowedOrigins";
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowedOrigins",
                                      policy =>
                                      {
                                          policy.WithOrigins()
                                                              .AllowAnyHeader()
                                                              .AllowAnyMethod();
                                      });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: policyName,
                                  builder =>
                                  {
                                      builder
                                        //.WithOrigins("http://localhost:8000")
                                        .AllowAnyOrigin()
                                        .WithMethods()
                                        .AllowAnyHeader();
                                  });
            });

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<MSCMSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IConfig, config>();
            builder.Services.AddScoped<cls_helper> ();
            builder.Services.AddScoped<cls_hasing>();
            //builder.Services.AddScoped<Ilogger, logger>();
            var logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .Enrich.FromLogContext()
              .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            //var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
            //Trace.Listeners.Add(new LoggerTraceListener(loggerFactory));


            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(policyName);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}