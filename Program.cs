using BBC.Api.Data;
using BBC.Api.Endpoint;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("BBCDB");

builder.Services.AddSqlServer<BBCContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapOrderEndpoint();

app.MapCustomerEndpoint();

app.MigrateDb();

app.Run();
