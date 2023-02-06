using ConferencePlanning.Data;
using ConferencePlanning.Data.Entities;
using ConferencePlanning.IdentityServices;
using ConferencePlanning.Services.ConferenceServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConferencePlanningContext>(options=>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConferencePlanningContext")));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy",policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddScoped<IConferenceService, ConferenceService>();

builder.Services.AddIdentityService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();