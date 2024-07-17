
using Project.BLL.ServiceInjections;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMapperService();

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(60);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContextService();
builder.Services.AddIdentityService();
builder.Services.AddManagerService();
builder.Services.AddRepService();
builder.Services.AddHttpContextAccessor();
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseSession();
app.MapControllers();

app.Run();
