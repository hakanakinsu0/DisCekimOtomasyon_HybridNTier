using Project.BLL.DependencyResolvers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextService();     //DependencyResolvers'tan geldi.
builder.Services.AddIdentityService();      //DependencyResolvers'tan geldi.
builder.Services.AddRepositoryService();    //DependencyResolvers'tan geldi.
builder.Services.AddMapperService();        //DependencyResolvers'tan geldi.
builder.Services.AddManagerService();       //DependencyResolvers'tan geldi.

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   
app.UseAuthorization();    

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
