using System.Text;
using ImageAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SC.Internship.Common.ScResult;
using SpaceAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHostedService<RMQListener>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISpaceContext, SpaceContext>();
builder.Services.Configure<RMQOptions>(options =>
{
    options.Port = Convert.ToInt32(builder.Configuration.GetSection("RabbitMq:Port").Value);
    options.HostName = builder.Configuration.GetSection("RabbitMq:Host").Value!;
    options.UserName = builder.Configuration.GetSection("RabbitMq:UserName").Value!;
    options.Password = builder.Configuration.GetSection("RabbitMq:Password").Value!;
    options.VirtualHost = builder.Configuration.GetSection("RabbitMq:VirtualHost").Value!;

});

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

app.Use(async (context, next) =>
{

    using StreamReader sr = new StreamReader(context.Request.Body,Encoding.UTF8, true, 1024, true);
    // ReSharper disable once IdentifierTypo
    var bodystring = await sr.ReadToEndAsync();
    // ReSharper disable once IdentifierTypo
    var headerstring = "";
    foreach (var item in context.Request.Headers)
    {
        headerstring += $"{item.Key}={item.Value}\n";
    }
    app.Logger.LogInformation("Request {0} \n {1} \n {2} ", context.Request.Method,bodystring,headerstring);
    await next.Invoke();
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ISpaceContext spaceContext = new SpaceContext();
app.MapGet("/spaces", () => new ScResult<List<Space>>()
    {
        Result = spaceContext.GetSpaces()
    })
    .WithOpenApi().RequireAuthorization();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();