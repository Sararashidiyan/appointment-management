using AppointmentManagement.Query.Application;
using AppointmentManagement.Query.Application.Interfaces.Doctors;
using AppointmentManagement.Query.Application.Interfaces.DoctorSchadules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDoctorQueryService, DoctorQueryService>();
builder.Services.AddScoped<IDoctorScheduleService, DoctorScheduleQueryService>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
