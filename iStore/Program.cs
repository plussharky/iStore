using iStore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    //opts.UseSqlServer(builder.Configuration["ConnectionStrings:iStoreConnection"]);

    opts.UseSqlite(builder.Configuration["ConnectionStrings:SQLite"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Order",
    pattern: "/Order",
    defaults: new { Controller = "Order", action = "Checkout" });

app.MapControllerRoute("catpage",
 "{category}/Page{productPage:int}",
 new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page", "Page{productPage:int}",
 new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("category", "{category}",
 new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute(
    name: "pagination",
    pattern: "Page{productPage}",
    defaults: new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute(
    name: "pagination",
    pattern: "/",
    defaults: new { Controller = "Home", action = "Index", productPage = 1 });

app.MapRazorPages();

SeedData.EnsurePopulated(app);

app.Run();