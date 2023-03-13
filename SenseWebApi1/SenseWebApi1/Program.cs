using MediatR;
using SenseWebApi1.Features.MyFeature.MyFeatureController.Validators;
using SenseWebApi1.Mapping;
using SenseWebApi1.Stubs;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton<IEventContext,EventContext>();
builder.Services.AddSingleton<IImageContext, ImageContext>();
builder.Services.AddSingleton<IAreaContext, AreaContext>();
builder.Services.AddAutoMapper(typeof (EventProfile),typeof (ImageProfile),typeof (AreaProfile));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
