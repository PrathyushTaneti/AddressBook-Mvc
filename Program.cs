using AddressBook.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json").Build();

builder.Services.AddDbContext<AddressBookContext>(option => option.UseSqlServer(configuration.GetConnectionString("DbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PersonDetails}/{action=Index}/{id?}");

app.Run();
