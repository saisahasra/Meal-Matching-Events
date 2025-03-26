using DDD_work.Data; 
using DDD_work.Services; 
using Microsoft.AspNetCore.Components; 
using Microsoft.AspNetCore.Components.Web; 

var builder = WebApplication.CreateBuilder(args); // creates a web application builder

// add services to the container
builder.Services.AddRazorPages(); // adds support for razor pages
builder.Services.AddServerSideBlazor(); // adds support for server-side blazor
builder.Services.AddSingleton<WeatherForecastService>(); 
builder.Services.AddScoped<UserDataService>();
builder.Services.AddScoped<DDD_work.Services.Auth.UserService>();
builder.Services.AddSingleton<DDD_work.Services.Match.MatchService>();

var app = builder.Build(); // builds the web application

// configure the http request pipeline
if (!app.Environment.IsDevelopment()) 
{
    app.UseExceptionHandler("/Error"); // sets the error handling page
    
    app.UseHsts(); // enables http strict transport security
}

app.UseHttpsRedirection(); // redirects http requests to https

app.UseStaticFiles(); // serves static files like css and images

app.UseRouting(); // enables routing for the application

app.MapBlazorHub(); // maps the blazor hub for real-time communication
app.MapFallbackToPage("/_Host"); // sets the fallback page for routing


app.Run(); // runs the web application