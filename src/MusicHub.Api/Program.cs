using Microsoft.EntityFrameworkCore;
using MusicHub.Api.Data;
using MusicHub.Api.Interfaces;
using MusicHub.Api.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddTransient<ITrackService, TrackService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();