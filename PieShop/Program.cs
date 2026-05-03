using Microsoft.EntityFrameworkCore;
using PieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


// builder.Services.AddDbContext<AppDbContext>(opts => opts.UseInMemoryDatabase("PieShopDb"));
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("PieShopDb")));
var app = builder.Build();

//DataSeeder.Initialize(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.MapStaticAssets();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pie}/{action=List}/{id?}")
    .WithStaticAssets();



app.Run();

