using BlazingPizza.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
//���Զ��� DbContext���˴���CarDbContext�� ��ӵ� DI ����
//DI������ASP.NET Core Ӧ�ó�������ṩ����Ҳ��Ϊ������ϵע������
builder.Services.AddDbContext<PizzaStoreContext>(opt => opt.UseMySql(
		builder.Configuration.GetConnectionString("MySqlConnection"),
		new MySqlServerVersion(new Version("8.0.30"))));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register the pizzas service
//builder.Services.AddSingleton<PizzaService>();

//��ӷ���
builder.Services.AddScoped<PizzaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
	var psdb = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
	if (psdb.Database.EnsureCreated())
	{
		SeedData.InitializePizzaSpecial(psdb);
		//if (!psdb.Pizzas.Any())
		//{
		//    SeedData.InitializePizza(psdb);
		//}
	}
}

app.Run();