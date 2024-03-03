using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

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
        config.WithOrigins(builder.Configuration["AllowedOrigins"]);
        config.AllowAnyHeader();
        config.AllowAnyMethod();
    });

    options.AddPolicy(name: "AnyOrigin", config =>
    {
        config.AllowAnyHeader();
        config.AllowAnyMethod();
        config.AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Show debug page if in development
if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
{
    app.UseDeveloperExceptionPage();
}
else app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

// Enable CORS
app.UseCors();
app.UseAuthorization();

// endpoint for error handling
app.MapGet("/error",
    [EnableCors("AnyOrigin")] [ResponseCache(NoStore = true)]
    () => Results.Problem());
app.MapGet("/error/test",
    [EnableCors("AnyOrigin")] [ResponseCache(NoStore = true)]
    () => { throw new Exception("test"); });

app.MapControllers();

app.Run();
