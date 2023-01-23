using Autofac;
using Autofac.Extensions.DependencyInjection;
using E_CommerceApp.Application.IoC;
using E_CommerceApp.Infrastructure.Context;
using E_CommerceApp.MVC.Models.SeedData;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ECommerceAppDbContext>(_ =>
{
    _.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"));
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(_ =>
{
    _.LoginPath = "/Login/Login";
    _.Cookie = new CookieBuilder
    {
        Name = "EcommerceCookie",
        SecurePolicy = CookieSecurePolicy.Always,
        HttpOnly = true 
    };
    _.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    _.SlidingExpiration = true;
    _.Cookie.MaxAge = _.ExpireTimeSpan;
});

builder.Services.AddSession(_ =>
{
    _.IdleTimeout = TimeSpan.FromMinutes(15);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
SeedData.Seed(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();