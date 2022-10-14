using MyExchange.API.Infrastructure.Extensions;
using MyExchange.API;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
// Add services to the container.
startup.AddServices(builder.Services);

var webApplication = builder.Build();

// Configure the HTTP request pipeline.
startup.Configure(webApplication, webApplication.Environment);

await webApplication.RunAsync();

//Null reference dependant entities?
//IRepository Expression ?
//Common зачем?
//Переименовать BaseId?

//TODO
//Statistic and position logic
//-Add Authorization
//-Add Transactions handling
//-Add Global Exception handling


//AddScoped?