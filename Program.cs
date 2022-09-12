using BlazingPizza.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
//将自定义 DbContext（此处是CarDbContext） 添加到 DI 容器
//DI容器是ASP.NET Core 应用程序服务提供程序，也称为依赖关系注入容器
builder.Services.AddDbContext<PizzaStoreContext>(opt => opt.UseMySql(
		builder.Configuration.GetConnectionString("MySqlConnection"),
		new MySqlServerVersion(new Version("8.0.30"))));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register the pizzas service
//builder.Services.AddSingleton<PizzaService>();

//添加服务
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