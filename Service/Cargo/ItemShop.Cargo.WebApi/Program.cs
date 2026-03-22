using ItemShop.Cargo.Business.Abstract;
using ItemShop.Cargo.Business.Concrete;
using ItemShop.Cargo.Business.Mapping;
using ItemShop.Cargo.DAL.Abstracts;
using ItemShop.Cargo.DAL.Concrete;
using ItemShop.Cargo.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CargoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), t => t.MigrationsAssembly("ItemShop.Cargo.WebApi")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(GeneralMapping));


builder.Services.AddScoped<ICargoCompanyDAL, EFCargoCompoanyRepository>();
builder.Services.AddScoped<ICargoCustomerDAL, EfCargoCustomerRepository>();
builder.Services.AddScoped<ICargoDetailDAL, EFCargoDetailRepository>();
builder.Services.AddScoped<ICargoOperationDAL, EfCargoOperationRepository>();

builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
