using BookshelfAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

// configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        _ = config.WithOrigins(builder.Configuration["AllowedOrigins"]);
        _ = config.AllowAnyHeader();
        _ = config.AllowAnyMethod();
    });

    options.AddPolicy(name: "AnyOrigin", config =>
    {
        _ = config.AllowAnyHeader();
        _ = config.AllowAnyMethod();
        _ = config.AllowAnyOrigin();
    });
});

if (Environment.GetEnvironmentVariable("DOCKER") == "true")
{
    var connectionString = Environment.GetEnvironmentVariable("DOCKER_DB_STRING");
    // Docker deployment
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{   // Local development
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

// Show debug page if in development
if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
{
    _ = app.UseDeveloperExceptionPage();
}
else
{
    _ = app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors();
app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}
app.Run();
