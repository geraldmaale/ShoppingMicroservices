using Discount.Grpc.Services;
using Discount.Shared.Extensions;
using Discount.Shared.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.RegisterDbContextServiceCollection(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Run migration
MigrationExtension<Program>.MigrateDatabase(app);

app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();