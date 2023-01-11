using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using ShortenUrl.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShortenDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ShortenDbConn"),
        b => b.MigrationsAssembly(typeof(ShortenDbContext).Assembly.FullName)));
builder.Services.AddScoped<IShortenDbContext>(provider => provider.GetRequiredService<ShortenDbContext>());
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
{
    options.LoginPath = "/auth/login";
    options.LogoutPath = "/auth/logout";
});

var app = builder.Build();

// start code to add
// to get ip address
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
// end code to add

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error/500");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseRouting();
app.UseCookiePolicy();  
app.UseAuthentication(); 
app.UseAuthorization();

// app.MapControllerRoute(name: "r",
//     pattern: "r/{*u}",
//     defaults: new { controller = "Home", action = "index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();