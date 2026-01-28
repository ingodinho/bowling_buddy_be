using Bowling.Buddy.Api.Middlewares;
using Bowling.Buddy.Api.StartupTasks;
using Bowling.Buddy.Application.Dependencies;
using Bowling.Buddy.Infrastructure.Dependencies;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(config);

var app = builder.Build();
app.Services.ApplyInfrastructureStartupTasks();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();