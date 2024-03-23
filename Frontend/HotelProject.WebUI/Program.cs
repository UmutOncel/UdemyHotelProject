using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient();       //Controller'da tanýmlanan "IHttpClientFactory" aktif olmasý için.

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<HotelProjectDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HotelProjectDbContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Staff}/{action=Index}/{id?}");

app.Run();
