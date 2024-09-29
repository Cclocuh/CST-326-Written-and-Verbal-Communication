using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryStore.Data;
using OnlineGroceryStore.Services;
using OnlineGroceryStore.Models; // Import the ApplicationUser class

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Razor Pages service here
builder.Services.AddRazorPages();  // Required to use Razor Pages (Identity uses it)

// Configure the database connection
var connectionString = builder.Configuration.GetConnectionString("GroceryStoreDB");
builder.Services.AddDbContext<GroceryStoreContext>(options =>
    options.UseMySQL(connectionString));

// Add Identity services, and configure to use ApplicationUser instead of IdentityUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // Disable email confirmation
})
.AddEntityFrameworkStores<GroceryStoreContext>()
.AddDefaultTokenProviders();

// Register a simple IEmailSender implementation
builder.Services.AddSingleton<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add Authentication and Authorization middlewares
app.UseAuthentication();
app.UseAuthorization();

// Map Razor Pages for Identity
app.MapRazorPages();

// Map the default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




