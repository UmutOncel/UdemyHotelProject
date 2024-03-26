using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
{
    opt.RequireHttpsMetadata = false;   //Https gerekli olsun mu?(true olmasý istenir)
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = "http://localhost",   //yayýncýsý (üretici)
        ValidAudience = "http://localhost",     //dinleyicisi (tüketici)
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiaspnetcoreapiaspnetcoreapiaspnetcoreapiaspnetcoreapi")),    //JWT'nin 3. parametresi oluyor. Bu deðere göre yetkilendirme yapýlýyordu. Þifrelenen kýsým.
        ValidateIssuerSigningKey = true,     //yukarýdaki kodun çözümü saðlansýn
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero   //ortak bir zaman yaratýyor. bu kodu eklemeyince CreateToken kýsmýndaki expires kýsmý çalýþmýyor.
    };
});


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

app.UseAuthentication();    //biz ekledik.

app.UseAuthorization();

app.MapControllers();

app.Run();
