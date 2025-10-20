using AppointmentManagement.Api.Authorization;
using AppointmentManagement.Api.BackgroundServices;
using AppointmentManagement.Api.Extensions;
using AppointmentManagement.Application;
using AppointmentManagement.Application.Extensions;
using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using AppointmentManagement.Infrastructure;
using AppointmentManagement.Infrastructure.Extensions;
using AppointmentManagement.Infrastructure.ExternalResources.NotifyEngine.AuthServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ICurrentUserService,CurrentUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtAuthenticationService(builder.Configuration);
builder.Services.AddDbContext<AppointmentManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddNotifyEngineServices(builder.Configuration);
builder.Services.AddHostedService<NotifyEngineAuthenticateProcessor>();
builder.Services.AddLocationProviderServices(builder.Configuration);
builder.Services.AddAuthorizationPolicy();


var app = builder.Build();
await app.Services.InitializeDatabase();
app.MapGet("/health", () => Results.Ok("API is running"));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.Run();
