using Microsoft.AspNetCore.Mvc;
using MovieSearchApp_WebApi.Models;
using MovieSearchApp_WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});
builder.Services.AddHttpClient<IHttpClient, HttpClientWrapper>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddSingleton<IHtmlSanitizer, HtmlSanitizerWrapper>();

builder.Services.Configure<OmdbSettings>(builder.Configuration.GetSection("OmdbSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000") 
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); 
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");
    //context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
    await next();
});

app.MapControllers();

app.Run();
