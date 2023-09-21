using webapi.DbContext;
using webapi.services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// get config
var FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl");

// Add services to the container.
builder.Services.AddDbContextPool<MariaDbContext>(options => options
    .UseMySql(
        builder.Configuration.GetConnectionString("MariaDbConnectionString"),
        new MariaDbServerVersion(new Version(11, 1, 2))
    )
);
builder.Services.AddScoped<IMariaDbWealthService, MariaDbWealthService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(FrontendUrl);  //set the allowed origin, don't end with slash (/) 
        // policy.AllowAnyOrigin();  //set allow any origins  
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
