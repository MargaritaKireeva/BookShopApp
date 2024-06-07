using BookShopApp.BLL;
using BookShopApp.BLL.Interfaces;
using BookShopApp.DAL;
using BookShopApp.DAL.Interfaces;
using BookShopApp.Server.RabbitMQ;
using BookShopApp.Shared;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<IGenresBL, GenresBL>();
builder.Services.AddScoped<IGenresDAL, GenresDAL>();
builder.Services.AddScoped<IBooksBL, BooksBL>();
builder.Services.AddScoped<IBooksDAL, BooksDAL>();
builder.Services.AddScoped<IFeedbackBL, FeedbackBL>();
builder.Services.AddScoped<IFeedbackDAL, FeedbackDAL>();
builder.Services.AddScoped<IRabbitMqServiceBL, RabbitMqServiceBL>();
builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.Configure<DbSettings>(
    builder.Configuration.GetSection("BooksDb"));
/*builder.Services.Configure<RabbitMqService>(
    builder.Configuration.GetSection("RabbitMqString"));*/

builder.Services.AddControllersWithViews();
/* .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);*/
builder.Services.AddRazorPages();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
/*    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");*/
    endpoints.MapControllerRoute(
    name: "Genres",
    pattern: "/Genres/{genreId}");
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
