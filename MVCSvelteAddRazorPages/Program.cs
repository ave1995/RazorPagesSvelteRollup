global using Microsoft.AspNetCore.Mvc.RazorPages;
global using MVCSvelteAddRazorPages.Pages;
global using Microsoft.AspNetCore.Razor.Hosting;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCSvelteAddRazorPages.Data;
using MVCSvelteAddRazorPages;

#if DEBUG
if (MVCSvelteAddRazorPages.Scripts.Scripts.BuildModels(args))
{
    return;
}
if (MVCSvelteAddRazorPages.Scripts.Scripts.BuildUrls(args))
{
    return;
}
#endif

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.UseMiddleware<RequestDiagnosticsMiddleware>();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
