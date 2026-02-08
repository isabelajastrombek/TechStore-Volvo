using TechStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
using TechStore.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<ECommerceTechContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
