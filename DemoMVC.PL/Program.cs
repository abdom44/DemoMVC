using Demo.BL.Mapper;
using DemoMVC.PL.Language;
using DemoMVC.BL.Intenfaces;
using DemoMVC.BL.Repository;
using DemoMVC.DAL.Database;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using DemoMVC.DAL.Extends;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Newtonsoft
// add localization
builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
}).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
.AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
        factory.Create(typeof(SharedResource));
});

builder.Services.AddScoped<IDepartment, DepartmentRep >();
builder.Services.AddScoped<IEmployee, EmployeeRep >();
builder.Services.AddScoped<ICountry,CountryRep >();
builder.Services.AddScoped<ICity, CityRep >();
builder.Services.AddScoped<IDistrict, DistrictRep >();

//Newtonsoft

//connection string
var connectionString = builder.Configuration.GetConnectionString("DemoMVCConnection");

builder.Services.AddDbContext<DemoContext>(options =>
options.UseSqlServer(connectionString));


//auto mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

// authentication
//expire date for stay login
builder.Services.AddAuthentication().AddIdentityCookies(o =>
{
    o.TwoFactorRememberMeCookie.Configure(a => a.Cookie.Expiration = new TimeSpan(10, 00, 00, 00));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });



//generate token configuration
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DemoContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Default Password settings.
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<DemoContext>();

var app = builder.Build();

var supportedCultures = new[] {
    new CultureInfo("ar-EG"),
    new CultureInfo("en-US"),
};
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
    {
    new QueryStringRequestCultureProvider(),
    new CookieRequestCultureProvider()
    }
});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
