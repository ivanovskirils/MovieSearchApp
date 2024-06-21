using MovieSearchApp_WebApi.Interfaces;
using MovieSearchApp_WebApi.Models;
using MovieSearchApp_WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<MovieService>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.Configure<OmdbSettings>(builder.Configuration.GetSection("OmdbSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
