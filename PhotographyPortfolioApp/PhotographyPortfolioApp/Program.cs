// See https://aka.ms/new-console-template for more information

using PhotographyPortfolioApp.Data;

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PhotographyPortfolioAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

var app = builder.Build();
