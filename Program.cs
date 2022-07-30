using CircleAndComments.Data;
using CircleAndComments.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//строка подлючения к БД
var connectionString = builder.Configuration.GetConnectionString("CircleDB");
//получаем сервис контекста данных
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(connectionString));

//контейнер для Circle
builder.Services.AddTransient<IDataCircle, DataCircle>();

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.
            Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Circle/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Circle}/{action=Index}/{id?}");

//вызываем статический метод для загрузки тестовых данных в БД.
SeedData.EnsurePopulated(app);

app.Run();
