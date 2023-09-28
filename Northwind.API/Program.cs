using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Models;
using Northwind.BLL.Repositories;
using Northwind.BLL.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Dbcontext
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Scoped
builder.Services.AddScoped<ISupplierRepository, SupplierService>();

builder.Services.AddScoped<IShipperRepository, ShipperService>();

builder.Services.AddScoped<IProductRepository, ProductService>();

builder.Services.AddScoped<ICategoryRepository,CategoryService>();

builder.Services.AddScoped<IOrderRepository, OrderService>();

//Disturbed Session Configure
builder.Services.AddDistributedMemoryCache();

//Identity Service
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<NorthwindContext>();

//Session
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "product_cart";
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});

//CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", cors =>
    {
        cors.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("https://localhost:7089");
    });
});




var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("CORS");
app.MapControllers();
app.UseSession();

app.Run();