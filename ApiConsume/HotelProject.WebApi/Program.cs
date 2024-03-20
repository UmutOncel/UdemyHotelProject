using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

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


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
