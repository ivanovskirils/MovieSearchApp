using MovieSearchApp_WebApi.Models;
using MovieSearchApp_WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient<MovieService>();
builder.Services.AddScoped<IMovieService, MovieService>();

// Configure OmdbSettings
builder.Services.Configure<OmdbSettings>(builder.Configuration.GetSection("OmdbSettings"));

// Configure CORS to allow the frontend to access the API
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
