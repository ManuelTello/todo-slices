using Microsoft.EntityFrameworkCore;
using TodoSlices.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddDbContext<TodoSlicesDatabaseContext>(optins =>
{
    string mysqlConnection = builder.Configuration.GetConnectionString("mysql_connection")!;
    optins.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
