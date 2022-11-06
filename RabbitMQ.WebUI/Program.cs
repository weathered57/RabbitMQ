using MassTransit;
using RabbitMQ.Business.Abstract;
using RabbitMQ.Business.Concrete;
using RabbitMQ.DataAccess.Abstract;
using RabbitMQ.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductsService, ProductsManager>();
builder.Services.AddScoped<IProductsDal, EfProducts>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsManager>();
builder.Services.AddScoped<IOrderDetailsDal, EfOrderDetails>();
builder.Services.AddScoped<IOrderItemsService, OrderItemsManager>();
builder.Services.AddScoped<IOrderItemsDal, EfOrderItems>();


// Add services to the container.
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddMassTransit(options =>
{
    options.UsingRabbitMq((context, cfg) =>
       {
           cfg.Host(new Uri("rabbitmq://localhost"), h =>
           {
               h.Username("guest");
               h.Password("guest");
           });
       });
});

builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
