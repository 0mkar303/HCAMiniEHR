using HCAMiniEHR.Data;
using HCAMiniEHR.Repositories.Implementations;
using HCAMiniEHR.Repositories.Interfaces;
using HCAMiniEHR.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure Entity Framework and SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<ILabOrderRepository, LabOrderRepository>();
builder.Services.AddScoped<LabOrderService>();
//Register AppointmentRepository
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<DashboardService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
