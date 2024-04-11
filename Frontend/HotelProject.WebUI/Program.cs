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


builder.Services.AddScoped<IImageHelper, ImageHelper>();    //ImageHelper'ýn çalýþmasý için.

builder.Services.AddHttpClient();       //Controller'da tanýmlanan "IHttpClientFactory" aktif olmasý için.

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<HotelProjectDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HotelProjectDbContext>();

builder.Services.AddTransient<IValidator<AddGuestDTO>, AddGuestValidator>()
                .AddTransient<IValidator<UpdateGuestDTO>, UpdateGuestValidator>();
builder.Services.AddControllersWithViews().AddFluentValidation();


//Proje Seviyesinde Authorize: Yetkilendirme iþlemi için tek tek bütün controller'lara gidip "[Authorize]" yazmak yerine bu þekilde proje içindeki tüm sayfalara eriþimi engelleriz.
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

//Yukarýda yaptýðýmýz iþlemede þöyle bir sorunla karþýlarýz: Kullanýcýnýn tüm sayfalara girmesi engellenirse bu sefer kullanýcý hiçbir iþlem yapamaz. Öyleyse login, register, default/index (Hotelier) gibi sayfalara eriþim izni verilmeli. (Admin'e ait sayfalara eriþim kýsýtlý olmalýdýr.) Bunun için aþaðýdaki kodlarýn yaný sýra izin vermek istediðimiz controller'a gidip "[AllowAnonymous]" yazarýz.
builder.Services.ConfigureApplicationCookie(opt => 
{
    opt.Cookie.HttpOnly = true;
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(20);      //yetkilendirme 20 dakika sürsün.
    opt.LoginPath = "/Login/Index";                     //proje açýlýnca direkt login sayfasý gelsin.
    opt.AccessDeniedPath = "/ErrorPage/AccessDenied";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//hata sayfasýna yönlendirme için.
app.UseStatusCodePagesWithReExecute("/ErrorPage/ErrorPageNotFound", "?code={0}");   

app.UseRouting();

app.UseAuthentication();        //Proje Seviyesinde Authorize iþlemi için ekledik.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
