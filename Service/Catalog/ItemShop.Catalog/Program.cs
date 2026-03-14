using ItemShop.Catalog.Services.CategoryServices;
using ItemShop.Catalog.Services.ProductDetailServices;
using ItemShop.Catalog.Services.ProductImageServices;
using ItemShop.Catalog.Services.ProductServices;
using ItemShop.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority =builder.Configuration["IdentityServerUrl"];
    opt.Audience ="Resourceatalog";
    opt.RequireHttpsMetadata =false;
}
);
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
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CatalogWebAPI");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
