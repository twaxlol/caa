
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductOrder.Application.Mapping;
using ProductOrder.Application.Queries;
using ProductOrder.Core.Repositories;
using ProductOrder.Infrastructure.Data;
using ProductOrder.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var mapConfig = new MapperConfiguration(c =>
    c.AddProfile(new MappingProfile()
));
IMapper mapper = mapConfig.CreateMapper();


// Add services to the container.
builder.Services.AddSingleton(mapper);
builder.Services.AddMediatR(typeof(GetProductsListQuery).GetTypeInfo().Assembly);

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductOrderDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Db")));

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
