using MediatR;
using SenseWebApi1.Features.MyFeature.Validators;
using SenseWebApi1.Mapping;
using SenseWebApi1.Context;
using SenseWebApi1.Features.MyFeature.Middlewares;
using System.Reflection;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton<IEventContext,EventContext>();
builder.Services.AddSingleton<IImageContext, ImageContext>();
builder.Services.AddSingleton<IAreaContext, AreaContext>();
builder.Services.AddAutoMapper(typeof (EventProfile),typeof (ImageProfile),typeof (AreaProfile));
AssemblyScanner.FindValidatorsInAssembly(typeof(Program).Assembly)
  .ForEach(item => builder.Services.AddScoped(item.InterfaceType, item.ValidatorType));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalErrorHandler>();

app.Run();
