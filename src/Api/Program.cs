using FluentValidation;
using Vertical.Slice.Core;
using Vertical.Slice.Extensions;
using Vertical.Slice.Features;
using Vertical.Slice.Features.Features.V1.CreateOrder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddControllers()
    .Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddMediatRPipelines(typeof(FeaturesApi).Assembly)
    .AddLogging()
    .AddApiVersioning()
    .AddValidatorsFromAssemblyContaining<Validator>()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
app
    .AddIf(app.Environment.IsDevelopment(), app => app.UseSwagger().UseSwaggerUI())
    //.UseHttpsRedirection()
;

app.MapControllers();

await app.RunAsync();
