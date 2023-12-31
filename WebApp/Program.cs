﻿// Program.cs
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using DataAccess.Concrete.EntityFramework.Contexts;
using Dev_Folio.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
})
.AddEntityFrameworkStores<SuperFolioContext>()
.AddDefaultTokenProviders();

// Autofac
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication middleware'ini kullan
app.UseAuthentication();

app.UseAuthorization();

// Default rolleri ve kullanıcıyı oluştur
await RoleUtilities.EnsureRolesCreated(app.Services.GetRequiredService<RoleManager<IdentityRole>>());
await UserUtilities.EnsureDefaultUserCreated(app.Services.GetRequiredService<UserManager<IdentityUser>>());

app.MapControllerRoute(
    name: "area",
    pattern: "{area}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
