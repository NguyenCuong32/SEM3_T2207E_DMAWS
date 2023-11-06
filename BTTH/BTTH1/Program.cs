using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BTTH1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<BTTH1Context>(options =>
//  options.UseSqlServer(builder.Configuration.GetConnectionString("BTTH1Context") ?? throw new InvalidOperationException("Connection string 'BTTH1Context' not found.")));
var connectionString = builder.Configuration.GetConnectionString("BTTH1Context");
builder.Services.AddDbContext<BTTH1Context>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<BTTH1Context>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		   Path.Combine(builder.Environment.ContentRootPath, "viewslib")),
	RequestPath = "/viewslib"
});

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
