using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("Data");


builder.Services.AddScoped<IItemInterface, ItemRepository>(provider =>
    new ItemRepository(connectionString));
builder.Services.AddScoped<IPriceChangeInterface,PriceChangeRepository>(provider =>new PriceChangeRepository(connectionString));
var app = builder.Build();

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
