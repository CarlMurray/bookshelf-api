using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// endpoint for error handling
app.MapGet("/error",
    [EnableCors("AnyOrigin")][ResponseCache(NoStore = true)]
() => Results.Problem());
app.MapGet("/error/test",
    [EnableCors("AnyOrigin")][ResponseCache(NoStore = true)]
() =>
    { throw new Exception("test"); });


app.MapControllers();

app.Run();
