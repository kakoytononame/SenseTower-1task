using MediatR;
using SenseWebApi1.Context;
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.CookiePolicy;
using SenseWebApi1.MongoDB;
using SenseWebApi1.Common;
using SenseWebApi1.Common.Middlewares;
using SenseWebApi1.Features.EventFeature;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#pragma warning disable CS0618 

builder.Services.AddControllers();

builder.Services.AddMvc().AddControllersAsServices();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.Configure<Settings>(options =>
    {
        options.ConnectionString= builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
        options.Database=builder.Configuration.GetSection("MongoConnection:Database").Value;
    }
    
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allowall",
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                          policy.AllowCredentials();
                      });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddScoped<IEventContext,EventContext>();

builder.Services.AddSingleton<IImageContext, ImageContext>();

builder.Services.AddSingleton<IAreaContext, AreaContext>();

builder.Services.AddScoped<ITicketContext,TicketContext>();

builder.Services.AddScoped<IMongoDbContext, MongoDbContext>();

builder.Services.AddAutoMapper(typeof (EventProfile),typeof (ImageProfile),typeof (AreaProfile));

AssemblyScanner.FindValidatorsInAssembly(typeof(Program).Assembly)
  .ForEach(item => builder.Services.AddScoped(item.InterfaceType, item.ValidatorType));

ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.StopOnFirstFailure; 

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata=false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "MyAuthServer",
            ValidAudience = "MyAuthClient",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mysupersecret_secretkey!123")
            ),
        };
    }); 


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.Use(async (context, next) =>
{
    var token = context.Request.Cookies[".AspNetCore.Application.Id"];
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Xss-Protection", "1");
    if (!string.IsNullOrEmpty(token))
        context.Request.Headers.Add("Authorization", "Bearer " + token);

    await next();
});

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.None,
});


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalErrorHandler>();

app.Run();
