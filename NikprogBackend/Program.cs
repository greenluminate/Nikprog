using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NikprogServerClient.Data;
using NikprogServerClient.Logic;
using NikprogServerClient.Models.CourseMaterials;
using NikprogServerClient.Models.UserHandling;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MoniConnectionString");
builder.Services.AddDbContext<NikprogDbContext>(options =>
{
    options.UseSqlServer(connectionString)
    .UseLazyLoadingProxies();
    //options.UseInMemoryDatabase("db")
    //options.UseTriggers(triggerOptions =>
    // {
    //     triggerOptions.AddTrigger<SetSequenceNumberOnAdd>();
    //     //triggerOptions.AddTrigger<CreateWelcomeEmail>();
    //     //triggerOptions.AddTrigger<SendEmail>();
    // });
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Site"],
        ValidIssuer = builder.Configuration["Jwt:Site"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"]))
    };
});

builder.Services.AddCors();

builder.Services
    .AddControllers()
    .AddJsonOptions(opts =>
    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

builder.Services.AddScoped<ICRUDLogic<Course>, CRUDLogic<Course>>();
builder.Services.AddScoped<ICRUDLogic<Module>, CRUDLogic<Module>>();
builder.Services.AddScoped<ICRUDLogic<MaterialInfo>, CRUDLogic<MaterialInfo>>();
builder.Services.AddScoped<ICRUDLogic<MessageInfo>, CRUDLogic<MessageInfo>>();
builder.Services.AddScoped<ICRUDLogic<VideoInfo>, CRUDLogic<VideoInfo>>();
builder.Services.AddScoped<ICRUDLogic<DocumentInfo>, CRUDLogic<DocumentInfo>>();
builder.Services.AddScoped<IModuleLogic, ModuleLogic>();
builder.Services.AddScoped<IMaterialInfoLogic, MaterialInfoLogic>();

builder.Services.AddTransient<ICRUDRepository<Course>, CRUDRepository<Course>>();
builder.Services.AddTransient<ICRUDRepository<Module>, CRUDRepository<Module>>();
builder.Services.AddTransient<ICRUDRepository<MaterialInfo>, CRUDRepository<MaterialInfo>>();
builder.Services.AddTransient<ICRUDRepository<MessageInfo>, CRUDRepository<MessageInfo>>();
builder.Services.AddTransient<ICRUDRepository<VideoInfo>, CRUDRepository<VideoInfo>>();
builder.Services.AddTransient<ICRUDRepository<DocumentInfo>, CRUDRepository<DocumentInfo>>();
builder.Services.AddTransient<IModuleRepository, ModuleRepository>();
builder.Services.AddTransient<IMaterialInfoRepository, MaterialInfoRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NikprogRegen", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios,
    // see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NikprogRegen v1"));

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(t => t
.WithOrigins("https://localhost:44431", "https://localhost:32265")
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
