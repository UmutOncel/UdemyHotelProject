using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.DTOs.GuestDTOs;
using HotelProject.WebUI.Helpers.Images;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IImageHelper, ImageHelper>();    //ImageHelper'�n �al��mas� i�in.

builder.Services.AddHttpClient();       //Controller'da tan�mlanan "IHttpClientFactory" aktif olmas� i�in.

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<HotelProjectDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HotelProjectDbContext>();

builder.Services.AddTransient<IValidator<AddGuestDTO>, AddGuestValidator>()
                .AddTransient<IValidator<UpdateGuestDTO>, UpdateGuestValidator>();
builder.Services.AddControllersWithViews().AddFluentValidation();


//Proje Seviyesinde Authorize: Yetkilendirme i�lemi i�in tek tek b�t�n controller'lara gidip "[Authorize]" yazmak yerine bu �ekilde proje i�indeki t�m sayfalara eri�imi engelleriz.
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

//Yukar�da yapt���m�z i�lemede ��yle bir sorunla kar��lar�z: Kullan�c�n�n t�m sayfalara girmesi engellenirse bu sefer kullan�c� hi�bir i�lem yapamaz. �yleyse login, register, default/index (Hotelier) gibi sayfalara eri�im izni verilmeli. (Admin'e ait sayfalara eri�im k�s�tl� olmal�d�r.) Bunun i�in a�a��daki kodlar�n yan� s�ra izin vermek istedi�imiz controller'a gidip "[AllowAnonymous]" yazar�z.
builder.Services.ConfigureApplicationCookie(opt => 
{
    opt.Cookie.HttpOnly = true;
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(20);      //yetkilendirme 20 dakika s�rs�n.
    opt.LoginPath = "/Login/Index";                     //proje a��l�nca direkt login sayfas� gelsin.
    opt.AccessDeniedPath = "/ErrorPage/AccessDenied";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//hata sayfas�na y�nlendirme i�in.
app.UseStatusCodePagesWithReExecute("/ErrorPage/ErrorPageNotFound", "?code={0}");   

app.UseRouting();

app.UseAuthentication();        //Proje Seviyesinde Authorize i�lemi i�in ekledik.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
