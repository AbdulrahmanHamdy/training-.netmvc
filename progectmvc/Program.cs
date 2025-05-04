using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using progectmvc.Filters;
using progectmvc.Models;
using progectmvc.Repriditory;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
//builder.Services.AddControllersWithViews(option =>
//{
  //  option.Filters.Add(new HandelErrorAttribute());
//});
builder.Services.AddControllersWithViews();

//coustem Services to deal with the interdace
builder.Services.AddDbContext<Context>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
    //options.UseSqlServer("Data Source=LOKi;Initial Catalog=dbc; Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
});
builder.Services.AddScoped<IDepartmentReprository, Departmenrep>();
builder.Services.AddScoped<IEmployeeReprository, Employeerep>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
