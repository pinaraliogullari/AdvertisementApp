using AdvertisementApp.Business.Extensions;
using AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
     .AddCookie(options =>
     {
         options.Cookie.Name = "AdvertisementCookie";
         options.Cookie.HttpOnly = true;
         options.Cookie.SameSite = SameSiteMode.Strict;
         options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
         options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
         options.LoginPath= "/Account/SignIn";
         options.LogoutPath= "/Account/LogOut";
         options.AccessDeniedPath = "/Account/AccessDenied";
     });
builder.Services.AddControllersWithViews();
builder.Services.AddContext();
builder.Services.AddServices();
builder.Services.AddValidationAndMappingServices();
builder.Services.AddValidationServices();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
