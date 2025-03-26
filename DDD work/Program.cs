using Microsoft.AspNetCore.Components.Web;
using DDD_work.Services; 
using DDD_work.Services.Auth; // for login and stuff
using DDD_work.Services.Match; // the matching logic
using DDD_work.Data; 

var builder = WebApplication.CreateBuilder(args); // this builds the web app

// add all the services we need for now
builder.Services.AddRazorPages(); // for regular web pages
builder.Services.AddServerSideBlazor(); 
builder.Services.AddSingleton<WeatherForecastService>(); // I want to remove this but im scared
builder.Services.AddScoped<UserDataService>(); // gets user data
builder.Services.AddScoped<UserService>(); // handles user info
builder.Services.AddSingleton<MatchService>(); // for matching users
builder.Services.AddHttpClient(); // allows  web calls

var app = builder.Build(); // the app is ready

// set up how the app handles things
if (!app.Environment.IsDevelopment()) // if we're not in development mode
{
    app.UseExceptionHandler("/Error"); // show an error page if things break
   
    app.UseHsts();
}

app.UseHttpsRedirection(); // force https
app.UseStaticFiles(); // serve up our static files like css

app.UseRouting(); // figure out the routes

app.MapBlazorHub(); // for the blazor connection
app.MapFallbackToPage("/_Host"); // if nothing else matches, go here

app.Run(); // start the app running