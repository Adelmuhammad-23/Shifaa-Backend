using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShifaaAPI;
using ShifaaAPI.DbContext;
using ShifaaAPI.Helper;
using ShifaaAPI.Hubs;
using Stripe;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddSignalR();


#region DependencyInjection
builder.Services.AddServiceRegistration()
                .AddDependencis();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Stripe Settings
builder.Services.Configure<StripeModel>(builder.Configuration.GetSection("Stripe"));
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ChargeService>();
#endregion
// Add JWT Authentication
#region JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
        };
    });
#endregion
builder.Services.AddControllers();

//CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ShifaaAPI",
        Version = "v1",
        Description = "API Documentation for ShifaaAPI"
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("Policy");

app.UseAuthentication();
app.UseAuthorization();
app.MapHub<ChatHub>("/chat");
app.MapControllers();

app.Run();
