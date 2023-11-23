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

services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
    })
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<Art_Gallery_ProjectContext>();


services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});
services.AddHttpContextAccessor();
services.AddAuthorization(options =>
{
    options.AddPolicy("ArtistOnly", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var loggedInUser =
                Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(context.User.Identity);
            var queryId = new HttpContextAccessor().HttpContext.Request.Query["user"];
            return queryId == loggedInUser;
        });
    });
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
services.AddRazorPages();

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