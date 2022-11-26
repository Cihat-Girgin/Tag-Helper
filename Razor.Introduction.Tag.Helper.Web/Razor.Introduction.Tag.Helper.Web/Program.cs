using Microsoft.EntityFrameworkCore;
using Razor.Introduction.Tag.Helper.Web.DatabaseContexts;
using Razor.Introduction.Tag.Helper.Web.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UserDatabaseContext>(options =>
{
    options.UseInMemoryDatabase("UserInMemoryDatabase");
});

var app = builder.Build();

AddUserData(app);

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


static void AddUserData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<UserDatabaseContext>();

    List<User> userList = new() {
        new User{
            Id = new Guid(),
            Username = "user-x",
            Email = "userx@user.com",
            Name = "user",
            Lastname = "x",
            Password = "pass"
        },
        new User{
            Id = new Guid(),
            Username = "user-y",
            Email = "usery@user.com",
            Name = "user",
            Lastname = "y",
            Password = "pass"
        },
        new User{
            Id = new Guid(),
            Username = "user-z",
            Email = "userz@user.com",
            Name = "user",
            Lastname = "z",
            Password = "pass"
        }
    };

    db.Users.AddRange(userList);

    db.SaveChanges();
}
