using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NikprogBackend.Data;
using NikprogBackend.Models.UserHandling;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NikprogDbContext>(options =>
    //options.UseSqlServer(connectionString));
    options.UseInMemoryDatabase("db")
    .UseLazyLoadingProxies());
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<NikprogUser, IdentityRole>(
        options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 0;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        }
    ).AddEntityFrameworkStores<NikprogDbContext>()
     .AddDefaultTokenProviders();

//builder.Services.AddDefaultIdentity<NikprogUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<NikprogDbContext>();

//builder.Services.AddIdentityServer()
//    .AddApiAuthorization<NikprogUser, NikprogDbContext>();

//builder.Services.AddAuthentication()
//    .AddIdentityServerJwt();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = builder.Configuration["Jwt:Site"],
        ValidIssuer = builder.Configuration["Jwt:Site"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"]))
    };
});

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NikprogRegen", Version = "v1" });
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NikprogRegen v1"));

app.UseCors(t => t
.WithOrigins("https://localhost:44431")
.AllowAnyHeader()
.AllowCredentials()
.AllowAnyMethod());

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
