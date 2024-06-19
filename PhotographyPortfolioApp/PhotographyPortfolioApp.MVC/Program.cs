using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using PhotographyPortfolioApp.Data;
using PhotographyPortfolioApp.Service;
using PhotographyPortfolioApp.Data.Repos;
using PhotographyPortfolioApp.MVC;
using PhotographyPortfolioApp.Shared.Extentions;
using EntityFrameworkCore.UseRowNumberForPaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PhotographyPortfolioAppDbContext>(options =>
{
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"], 
                r => r.UseRowNumberForPaging());
});

builder.Services.AutoBind(typeof(PhotoService).Assembly);
builder.Services.AutoBind(typeof(PhotoRepository).Assembly);
builder.Services.AddAutoMapper(m => m.AddProfile(new AutoMapperConfiguration()));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PhotographyPortfolioAppDbContext>();
    // Automatically update database
    context.Database.Migrate();
}

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