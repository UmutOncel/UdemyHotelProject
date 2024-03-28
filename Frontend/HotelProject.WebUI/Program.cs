using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.GuestDTOs;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient();       //Controller'da tanýmlanan "IHttpClientFactory" aktif olmasý için.

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<HotelProjectDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HotelProjectDbContext>();


// Add services to the container.

builder.Services.AddTransient<IValidator<AddGuestDTO>, AddGuestValidator>()
                .AddTransient<IValidator<UpdateGuestDTO>, UpdateGuestValidator>();

builder.Services.AddControllersWithViews().AddFluentValidation();

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
