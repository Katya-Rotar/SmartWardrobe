using BLL;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Context;
using DAL.Helpers.Search;
using DAL.Helpers.Sorting;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
var connectionString = builder.Configuration.GetConnectionString("PgsqlConnection");
builder.Services.AddDbContext<WardrobeDbContext>(options =>
{
    options.EnableSensitiveDataLogging();
    options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Repositories + UoW
builder.Services.AddScoped(typeof(ISortHelper<>), typeof(SortHelper<>));
builder.Services.AddScoped(typeof(ISearchHelper<>), typeof(SearchHelper<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClothingItemRepository, ClothingItemRepository>();

// Services
builder.Services.AddScoped<IClothingItemService, ClothingItemService>();

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WardrobeDbContext>();
    await dbContext.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

await app.RunAsync();