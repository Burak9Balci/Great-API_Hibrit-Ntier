using Project.BLL.ServiceInjections;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromSeconds(10);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;

});
builder.Services.AddAuthenticationAndCookieService();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMapperService();
builder.Services.AddManagerService();
builder.Services.AddRepositoryService();
builder.Services.AddDbContextService();
builder.Services.AddManagerService();
builder.Services.AddIdentityService();
builder.Services.AddDistributedMemoryCache();
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "AdminPanel",
    pattern: "{area}/{controller=Author}/{action=GetAuthors}/{id?}");

app.Run();
