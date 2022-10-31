using Invoiceify.API;
using Invoiceify.API.Middleware;
using Invoiceify.API.Services;
using Invoiceify.API.Services.Interfaces;
using Invoiceify.Entities;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add logging
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<InvoiceifyDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<BusinessSeeder>();
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

//Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
    });
});

//Build app
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();

//Seeder
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<BusinessSeeder>();
seeder.Seed();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();