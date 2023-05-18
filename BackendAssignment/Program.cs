using BackendAssignment.Data;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                       policy =>
                       {
                           policy.WithOrigins("http://localhost:4200")
                                               .AllowAnyHeader()
                                               .AllowAnyMethod();
                       });
});

builder.Services.AddDbContext<AssignmentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

//app.UseCors(x=>x
//            .AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
