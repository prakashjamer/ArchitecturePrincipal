using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieManagement;
using MovieManagement.DataAccess.Context;
using MovieManagement.DataAccess.Repository;
using MovieManagement.Helper;
using MovieManagementBusiness;
using MovieManagementDomain.Interface.Repository;
using Serilog;
using System;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieManagementDbContext>(option =>
// Add Connection String 
option.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddMvc().
    AddJsonOptions(c => c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddCustomMvc().AddDomainDepedency().AddBusinessDepedency().AddAutoMapper(typeof(AutoMapperProfile));
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();
Log.Logger.Information("Serilog workig fine ...");
builder.Host.UseSerilog(((ctx, lc) => lc
.ReadFrom.Configuration(ctx.Configuration)));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o => o.TokenValidationParameters =
new Microsoft.IdentityModel.Tokens.TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(10));
builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetSection("RedisConnection").GetValue<string>("Configuration");
    option.InstanceName = builder.Configuration.GetSection("RedisConnection").GetValue<string>("InstanceName");
});

var app = builder.Build();
/// code to  run migration 
using (var scope = app.Services.CreateScope())
{
    await using var dbContext = scope.ServiceProvider.GetRequiredService<MovieManagementDbContext>();
    await dbContext.Database.MigrateAsync();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseSession();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.UseRouting();

app.UseSerilogRequestLogging();
Log.Information($"Application Start.... {System.DateTime.Now.ToString("dd mm yyyy")}");
app.Run();
