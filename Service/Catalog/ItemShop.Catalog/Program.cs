using ItemShop.Catalog.Services.CategoryServices;
using ItemShop.Catalog.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CatalogWebAPI", policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyHeader()                 
              .AllowAnyMethod();             
    });
});
builder.Services.AddScoped<ICategoryService, CategoryServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CatalogWebAPI");
app.UseAuthorization();
app.MapControllers();

app.Run();
