using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using StudyPro.Models.Interfaces.Authentication;
using StudyPro.Models.Interfaces.Cryptography;
using StudyPro.Models.Interfaces.Data;
using StudyPro.Services.Authentication;
using StudyPro.Services.Cryptography;
using StudyPro.Services.Data;
using StudyPro.Services.Data.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            options.SlidingExpiration = true;
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
        });

builder.Services.AddSession();
builder.Services.AddMemoryCache();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();


// data context
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudyProDataContext>(options => options.UseSqlServer(connection));

// custom services
builder.Services.AddScoped<IUserAuthService, CookieUserAuthService>();
builder.Services.AddScoped<IHasher, HashProvider>();
builder.Services.AddScoped<IUserService, EFUserService>();
builder.Services.AddScoped<ICardService, EFCardService>();
builder.Services.AddScoped<ICategoryService, EFCategoryService>();

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
    app.UseRouteDebugger();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//add these - for custom authentication
app.UseSession();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
