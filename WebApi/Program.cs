
using Empresa.Aplicacion.Infraestructura.Data;
using Empresa.Aplicacion.Infraestructura.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using Empresa.Aplicacion.Transversal.Mapper;
using Empresa.Aplicacion.Application.Interface;
using Empresa.Aplicacion.Application.Main;
using Empresa.Aplicacion.Domain.Interface;
using Empresa.Aplicacion.Domain.Core;
using Empresa.Aplicacion.Infraestructura.Interface;
using WebApi.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("").Value));
//Especificamos el uso de sql server y la cadena de conexion
//NET 6 ya no trae el archivo startup
builder.Services.AddDbContext<ConnectionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsHistoryTable("__EFMigrationsHistory"));
});



var appSettingsSection = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);

//Features
var appSettings = appSettingsSection.Get<AppSettings>();
string myPolicy = "policyApiEcommerce";//appSettings.OriginCors


//Authentication
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var Issuer = appSettings.Issuer;
var Audience = appSettings.Audience;
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userId = int.Parse(context.Principal.Identity.Name);
            return Task.CompletedTask;
        },

        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = Issuer,
        ValidateAudience = true,
        ValidAudience = Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

//Inyection
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();
builder.Services.AddScoped<IUsuarioDomain, UsuarioDomain>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICalificacionApplication, CalificacionApplication>();
builder.Services.AddScoped<ICalificacionDomain, CalificacionDomain>();
builder.Services.AddScoped<ICalificacionRepository, CalificacionRepository>();

//Swagger
// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Globokas",
        Description = "A simple example ASP.NET Core Web API",
        TermsOfService = new Uri("https://pacagroup.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Julio Carrera",
            Email = "juliocarrerac@outlook.com",
            Url = new Uri("https://globokas.net/")
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://globokas.net/")
        }
    });
    // Set the comments path for the Swagger JSON and UI.
    //Propiedades de la api menu build, habilitar xml en output
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);


    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };


    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new List<string>() { } }
                });
});

builder.Services.AddCors(options =>
                         options.AddPolicy(myPolicy,
                         builder => builder.WithOrigins("http://localhost:4200")
                                                                            .AllowAnyHeader()
                                                                            .AllowAnyMethod()));
builder.Services.AddMvc();

//builder.Services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2)
//    .AddJsonOptions(options => { options.JsonSerializerOptions. = new Newtonsoft.Json.Serialization.DefaultContractResolver(); });


//Mapeamos la estructura Config del appsettings.json a las clase AppSettings













// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Ecommerce V1");
});

app.UseCors(myPolicy);



app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
