using CircleAndComments.Data;
using CircleAndComments.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//������ ���������� � ��
var connectionString = builder.Configuration.GetConnectionString("CircleDB");
//�������� ������ ��������� ������
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(connectionString));

//��������� ��� Circle
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

//�������� ����������� ����� ��� �������� �������� ������ � ��.
SeedData.EnsurePopulated(app);

app.Run();
