using Microsoft.EntityFrameworkCore;
using Network.API.Model;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext

builder.Services.AddDbContext<APIDbContext>(optionts => optionts.UseSqlServer(builder.Configuration.GetConnectionString("TaskConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyToApp", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("PolicyToApp");
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<APIDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
