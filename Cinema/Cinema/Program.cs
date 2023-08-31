using CinemaApp.Models;
using CinemaApp.Services;
using CinemaApp.Services.DataBases.EFCore;
using CinemaApp.Services.DataBases.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDataBase, JsonDataBase>();
builder.Services.AddSingleton<IDataBase, EFCoreDataBase>();
builder.Services.AddSingleton<JsonDbContext>();
builder.Services.AddSingleton<JsonDbContext>();

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
