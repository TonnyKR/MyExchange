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

//TODO
//Validation


//Questions
//Null reference dependant entities
//IRepository Expression
//Update bank card and other nonsense crud
//Default properties
//WalletsPromoCode interaction?
//Controllers return
