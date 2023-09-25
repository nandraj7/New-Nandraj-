using AutoMapper;
using LeadTracker.API.Extensions;
using LeadTracker.Application.IService;
using LeadTracker.Application.Service;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Extension;
using LeadTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

//var config = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DBContext
var connectionOptions = new ConnectionOptions();

builder.Configuration.GetSection("ConnectionOptions").Bind(connectionOptions);

builder.Services.AddDbContext<LeadTrackerContext>(options => options.UseSqlServer(connectionOptions.DbConnection));
#endregion

#region Mapper, Repositories and Services

builder.Services.AddAutoMapper(typeof(MappingProfile),typeof(MappingProfile));

builder.Services.AddRepositories();
builder.Services.AddServices();
#endregion

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

//IConfiguration GetConfiguration()
//{
//    builder.Configuration
//    .Add("MyIniConfig.ini", optional: true, reloadOnChange: true)
//    .add($"MyIniConfig.{builder.Environment.EnvironmentName}.ini",
//                optional: true, reloadOnChange: true);


//}
