using AppointmentManagement.Api.Extensions;
using AppointmentManagement.Application;
using AppointmentManagement.Application.Extensions;
using AppointmentManagement.Application.Interfaces.SystemUserAuth;
using AppointmentManagement.Infrastructure;
using AppointmentManagement.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ICurrentUserService,CurrentUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtAuthenticationService(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddDbContext<AppointmentManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
await app.Services.InitializeDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
