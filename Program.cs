using HCAMiniEHR.Data;
using HCAMiniEHR.Models;
using HCAMiniEHR.Repositories.Implementations;
using HCAMiniEHR.Repositories.Interfaces;
using HCAMiniEHR.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure Entity Framework and SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

// Register repositories and services

//Register the Authorized Pages
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");
    options.Conventions.AllowAnonymousToPage("/Account/Login");
    options.Conventions.AllowAnonymousToPage("/Account/Register");
});

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

//Register Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options=>
{
    // LOGIN SETTINGS
    options.SignIn.RequireConfirmedAccount = false;

    // PASSWORD SETTINGS (demo-friendly)
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

    // 🔐 LOCKOUT SETTINGS (IMPORTANT)
    options.Lockout.AllowedForNewUsers = true;              // Enable lockout
    options.Lockout.MaxFailedAccessAttempts = 3;            // 3 wrong attempts
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30); // Freeze for 30 seconds
}    )
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});


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
app.UseAuthentication();


app.UseAuthorization();

app.MapRazorPages();
// This block runs once when the app starts:
// 1. Applies any pending migrations → creates tables if they don't exist
// 2. Seeds roles and test users so you can log in immediately
using (var scope = app.Services.CreateScope())
{
    // Get our DbContext from the service provider
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();  // Automatically creates/updates database schema (tables)

    // Get managers for roles and users
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Array of role names we want to ensure exist
    string[] roles = { "Doctor", "Admin" };

    // Create each role if it doesn't already exist
    foreach (var roleName in roles)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Seed Doctor user if it doesn't exist
    var doctorEmail = "doctor@clinic.com";
    var doctor = await userManager.FindByEmailAsync(doctorEmail);
    if (doctor == null)
    {
        doctor = new ApplicationUser
        {
            UserName = doctorEmail,
            Email = doctorEmail,
            EmailConfirmed = true  // Skip confirmation step for demo
        };
        var result = await userManager.CreateAsync(doctor, "Doctor@2026");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(doctor, "Doctor");
        }
    }

    // Seed LabTech user if it doesn't exist
    var AdminEmail = "Admin@clinic.com";
    var admin = await userManager.FindByEmailAsync(AdminEmail);
    if (admin == null)
    {
        admin = new ApplicationUser
        {
            UserName = AdminEmail,
            Email = AdminEmail,
            EmailConfirmed = true
        };
        var result = await userManager.CreateAsync(admin, "admin@2026");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}



app.Run();
