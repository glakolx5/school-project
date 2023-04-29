using csharp_mongo_webapi.Infrastructure;
using csharp_mongo_webapi.Models;
using csharp_mongo_webapi.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// create a server configuration using Serverconfig from Infrastructure
var config = new ServerConfig();

//binds my config to builder
builder.Configuration.Bind(config);

//connects to mongodb at startup 
var infoContext = new InfoContext(config.mongoDbConfig);

//create a repository object using infoContext
var repository = new InfoRepository(infoContext);
//Singleton 
builder.Services.AddSingleton<IInfoRepository>(repository);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//This problem is only for development.
//I added this because my frontend cannot contact my Controller without it
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
    b => b.AllowAnyHeader().
        AllowAnyOrigin().
        AllowAnyMethod()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
