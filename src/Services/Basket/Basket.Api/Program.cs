
using Basket.Api.Repositories;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//public IConfiguration Configuration { get;}
builder.Services.AddControllers();
builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = configuration["CatcheSettings:ConnectionStrings"];
});
builder.Services.AddScoped<IBasketRepository, BasketRepository>();  
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

app.UseAuthorization();

app.MapControllers();

app.Run();
