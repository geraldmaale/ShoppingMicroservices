using Discount.Shared.Extensions;
using Discount.Shared.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDbContextServiceCollection(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IDiscountDapperRepository, DiscountDapperRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Run migration
MigrationExtension<Program>.MigrateDatabase(app);


app.UseAuthorization();

app.MapControllers();

app.Run();
