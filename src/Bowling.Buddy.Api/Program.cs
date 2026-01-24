using Bowling.Buddy.Api.StartupTasks;
using Bowling.Buddy.Infrastructure.Dependencies;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddOpenApi();
builder.Services.AddControllers();

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
app.MapControllers();

app.Run();