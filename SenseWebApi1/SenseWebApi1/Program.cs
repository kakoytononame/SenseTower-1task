using MediatR;
using SenseWebApi1.Features.MyFeature.Validators;
using SenseWebApi1.Mapping;
using SenseWebApi1.Context;
using SenseWebApi1.Features.MyFeature.Middlewares;
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
builder.Services.AddSingleton<IEventContext,EventContext>();
builder.Services.AddSingleton<IImageContext, ImageContext>();
builder.Services.AddSingleton<IAreaContext, AreaContext>();
builder.Services.AddSingleton<ITicketContext,TicketContext>();
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
