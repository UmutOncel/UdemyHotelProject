using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
{
    opt.RequireHttpsMetadata = false;   //Https gerekli olsun mu?(true olmas� istenir)
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = "http://localhost",   //yay�nc�s� (�retici)
        ValidAudience = "http://localhost",     //dinleyicisi (t�ketici)
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiaspnetcoreapiaspnetcoreapiaspnetcoreapiaspnetcoreapi")),    //JWT'nin 3. parametresi oluyor. Bu de�ere g�re yetkilendirme yap�l�yordu. �ifrelenen k�s�m.
        ValidateIssuerSigningKey = true,     //yukar�daki kodun ��z�m� sa�lans�n
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero   //ortak bir zaman yarat�yor. bu kodu eklemeyince CreateToken k�sm�ndaki expires k�sm� �al��m�yor.
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
