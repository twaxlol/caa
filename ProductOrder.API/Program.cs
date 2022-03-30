
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductOrder.Application.Commands;
using ProductOrder.Application.Mapping;
using ProductOrder.Application.Queries;
using ProductOrder.Core.Repositories;
using ProductOrder.Infrastructure.Data;
using ProductOrder.Infrastructure.Repositories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


/**********************/
/* SERVICE CONTAINERS */
/**********************/

// Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Mediator
builder.Services.AddMediatR(typeof(CreateProductCommand));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(ValidationBehavior<,>).Assembly);

// Repository
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));
builder.Services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));

// NET
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductOrderDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("ProductOrder.Infrastructure")));

builder.Services.AddTransient<ExcpetionHandlingMiddleware>();

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

app.UseMiddleware<ExcpetionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ProductOrderDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
