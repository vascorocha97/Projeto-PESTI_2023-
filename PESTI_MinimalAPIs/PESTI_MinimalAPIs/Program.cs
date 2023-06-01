using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PESTI_MinimalAPIs.Data;
using PESTI_MinimalAPIs.Endpoints.Internal;
using PESTI_MinimalAPIs.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

//Configure Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});
builder.Services.AddDbContext<DataContext>(ServiceLifetime.Scoped);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
    };
});
builder.Services.AddAuthorization();

// Register endpoints
//EndpointExtensions
builder.Services.AddEndpoints<Program>(builder.Configuration);

var app = builder.Build();

//TODO: Ver isto em condicoes
using (var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DataContext>();
    var userService = services.GetRequiredService<IUserService>();

    UserDataSeeder.SeedUsers(userService);
}


// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

//EndepointExtensions
app.UseEndpoints<Program>();

app.Run();  