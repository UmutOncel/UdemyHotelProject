using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.WebApi.Mapping;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<HotelProjectDbContext>();

builder.Services.AddScoped<IRoomDAL, EfRoomDAL>()
                .AddScoped<IRoomService, RoomManager>();

builder.Services.AddScoped<IStaffDAL, EfStaffDAL>()
                .AddScoped<IStaffService, StaffManager>();

builder.Services.AddScoped<IServiceDAL, EfServiceDAL>()
                .AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<ITestimonialDAL, EfTestimonialDAL>()
                .AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<ISubscribeDAL, EfSubscribeDAL>()
                .AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddScoped<IAboutDAL, EfAboutDAL>()
                .AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IBookingDAL, EfBookingDAL>()
                .AddScoped<IBookingService, BookingManager>();

builder.Services.AddScoped<IContactDAL, EfContactDAL>()
                .AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IGuestDAL, EfGuestDAL>()
                .AddScoped<IGuestService, GuestManager>();

builder.Services.AddScoped<ISendMessageDAL, EfSendMessageDAL>()
                .AddScoped<ISendMessageService, SendMessageManager>();

builder.Services.AddScoped<IMessageCategoryDAL, EfMessageCategoryDAL>()
                .AddScoped<IMessageCategoryService, MessageCategoryManager>();

builder.Services.AddScoped<IWorkLocationDAL, EfWorkLocationDAL>()
                .AddScoped<IWorkLocationService, WorkLocationManager>();

builder.Services.AddScoped<IAppUserDAL, EfAppUserDAL>()
                .AddScoped<IAppUserService, AppUserManager>();

builder.Services.AddAutoMapper(typeof(Program));

//Cors: API'nin baþka kaynaklar tarafýndan consume edilmesini(tüketilmesini) saðlayan metot.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HotelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//"builder.Services.AddControllers();" zaten vardý sonuna "AddNewtonsoftJson" ekledik. (Include metodu çalýþmasý için ekledik.)
builder.Services.AddControllers().AddNewtonsoftJson
    (
        opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("HotelApiCors");        //yukarýda yazdýðýmýz cors'u kullanmak için.

app.UseAuthorization();

app.MapControllers();

app.Run();
