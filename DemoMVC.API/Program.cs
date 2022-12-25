using Demo.BL.Mapper;
using DemoMVC.BL.Intenfaces;
using DemoMVC.BL.Repository;
using DemoMVC.DAL.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


builder.Services.AddScoped<IDepartment, DepartmentRep>();
builder.Services.AddScoped<IEmployee, EmployeeRep>();
builder.Services.AddScoped<ICountry, CountryRep>();
builder.Services.AddScoped<ICity, CityRep>();
builder.Services.AddScoped<IDistrict, DistrictRep>();

//Newtonsoft

//connection string
var connectionString = builder.Configuration.GetConnectionString("DemoMVCConnection");

builder.Services.AddDbContext<DemoContext>(options =>
options.UseSqlServer(connectionString));


//auto mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));



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


app.UseCors(options => options
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());
app.Run();
