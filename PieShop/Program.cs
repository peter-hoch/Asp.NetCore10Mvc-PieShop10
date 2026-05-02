var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();



app.MapStaticAssets();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();



app.Run();

