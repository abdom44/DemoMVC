using Demo.BL.Mapper;
using DemoMVC.BL.Intenfaces;
using DemoMVC.BL.Repository;
using DemoMVC.DAL.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDepartment, DepartmentRep >();
builder.Services.AddScoped<IEmployee, EmployeeRep >();

//connection string
var connectionString = builder.Configuration.GetConnectionString("DemoMVCConnection");

builder.Services.AddDbContext<DemoContext>(options =>
options.UseSqlServer(connectionString));


//auto mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
