using Core.Security;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using HospitalProject.DataAccess;
using HospitalProject.Service;
using Core.CrossCuttingConcerns.Exceptions;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();


//Jwt ioC kayitlarini yapilandiriyoruz.
builder.Services.AddSecurityDependencies();

//Veri tabani baglantilarini yapilandiriyoruz.
builder.Services.AddDataAccessDependencies(builder.Configuration);

//Service katmanindaki bagimliliklari yapilandiriyoruz.
builder.Services.AddServiceDependencies();

builder.Services.AddControllers();


TokenOptions tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
            RoleClaimType = ClaimTypes.Role
        };

    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();