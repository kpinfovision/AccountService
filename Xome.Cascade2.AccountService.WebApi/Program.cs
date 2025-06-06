using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Infrastructure.Data;
using Xome.Cascade2.AccountService.WebApi.Config;
using Xome.Cascade2.AccountService.WebApi.Middlewares;
using Azure.Messaging.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add DB Context
// builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

// configure dependencies using autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));
builder.Services.Configure<ServiceBusSettings>(
    builder.Configuration.GetSection("AzureServiceBus"));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CamundaService>();
builder.Services.AddScoped<AssetService>();
builder.Services.AddScoped<ValuationTypeService>();
builder.Services.AddScoped<LoadValuationService>();
builder.Services.AddScoped<SellerConfigService>();
builder.Services.AddScoped<ServiceBusPublisher>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));



//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontend", policy =>
//    {
//        //    policy.WithOrigins(
//        //        "http://localhost:5173",
//        //        "http://20.197.15.82:8090",
//        //        "http://20.197.15.82:8080",
//        //        "*" // <- Allow all origins for development
//        //        ) // <- React app URL on Azure
//        //          .AllowAnyMethod()
//        //          .AllowAnyHeader()
//        //          .AllowCredentials()
//        //          .AllowAnyOrigin();
//        //});
//        policy.WithOrigins(
//        "*" // <- Allow all origins for development
//        ) // <- React app URL on Azure
//          .AllowAnyMethod()
//          .AllowAnyHeader()
//          .AllowCredentials()
//          .AllowAnyOrigin();
//    });

//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
 {
     policy
         .AllowAnyOrigin()       // Allow all domains
         .AllowAnyHeader()       // Allow all headers
         .AllowAnyMethod();      // Allow all HTTP methods
 });
});

var app = builder.Build();
app.UseCors("AllowAll");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Ensures OnModelCreating().HasData() is applied
}

app.UseMiddleware<RequestLoggingMiddleware>();
// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
else if (app.Environment.IsProduction())
{

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CAMUNDA API POC");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
