using Microsoft.EntityFrameworkCore;
using Art_Gallery_Project.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<Art_Gallery_ProjectContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Art_Gallery_ProjectContext") ??
                      throw new InvalidOperationException(
                          "Connection string 'Art_Gallery_ProjectContext' not found.")));

services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Art_Gallery_ProjectContext>();

services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});

services.AddMemoryCache();
services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    }
);

// Add services to the container.
services.AddControllersWithViews();

// builder.Services.AddDbContext<ArtGalleryProjectContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("ArtGalleryProjectContext")));


var app = builder.Build();

app.UseSession();
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

app.MapRazorPages();
app.Run();