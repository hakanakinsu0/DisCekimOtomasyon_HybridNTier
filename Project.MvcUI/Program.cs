using Microsoft.EntityFrameworkCore;
using Project.DAL.ContextClasses;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services
    .AddDbContext<MyContext>(opts =>
        opts.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"))
            .UseLazyLoadingProxies()
    );

WebApplication app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
