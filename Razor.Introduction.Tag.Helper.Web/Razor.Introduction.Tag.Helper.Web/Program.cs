using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Razor.Introduction.Tag.Helper.Web.DatabaseContexts;
using Razor.Introduction.Tag.Helper.Web.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/account/login";
});

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

app.UseAuthentication();

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
            Password = "pass",
            PictureUrl = "/userpictures/userx.jpg",
            Description = "Lorem Ipsum dolor sit amet😍"
        },
        new User{
            Id = new Guid(),
            Username = "user-y",
            Email = "usery@user.com",
            Name = "user",
            Lastname = "y",
            Password = "pass",
            PictureUrl = "/userpictures/usery.jpg",
            Description = "Lorem Ipsum dolor sit amet 💯 "
        },
        new User{
            Id = new Guid(),
            Username = "user-z",
            Email = "userz@user.com",
            Name = "user",
            Lastname = "z",
            Password = "pass",
            PictureUrl = "/userpictures/userz.jpg",
            Description = "Lorem Ipsum dolor sit amet🔥 "
        },
         new User{
            Id = new Guid(),
            Username = "user-w",
            Email = "userw@user.com",
            Name = "user",
            Lastname = "w",
            Password = "pass",
            PictureUrl = "/userpictures/userw.jpg",
            Description = "Lorem Ipsum dolor sit amet😻 "
        }
    };

    db.Users.AddRange(userList);

    db.SaveChanges();
}
