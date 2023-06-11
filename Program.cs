using System.Security.Claims;
using System.Text;
using batch15webAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // your other stuff.

    // NLog: Setup NLog for Dependency injection
   

    //other classes that need the logger 

    builder.Services.AddControllers();

    // builder.Logging.ClearProviders();
    // builder.Host.UseNLog();
    var key = "This is our key that we are using to authorixe our user";

        builder.Services.AddSingleton<IAuthManager>(new AuthManager(key));
    builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

     builder.Services.AddAuthentication(x =>
            
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });
               builder.Services.AddAuthorization(y =>
               y.AddPolicy("Admin",  policy =>{
                policy.RequireRole("Admin");
                policy.RequireClaim(ClaimTypes.Email , "DRfghjkl");
               }));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

     builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    // Configure the HTTP request pipeline.
    // Other stuff
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

// var connectionString = builder.Configuration.GetConnectionString("ApplicationContext");

// Add services to the container.


// builder.Services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(connectionString));


// Configure the HTTP request pipeline.
