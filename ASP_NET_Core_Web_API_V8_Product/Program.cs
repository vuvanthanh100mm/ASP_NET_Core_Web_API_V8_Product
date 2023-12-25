using ASP_NET_Core_Web_API_V8_Product.Data;
using ASP_NET_Core_Web_API_V8_Product.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
// builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();
builder.Services.AddScoped<ILoaiRepository, LoaiRepositoryInMemory>();

//Register services here
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("MyDB")
));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
