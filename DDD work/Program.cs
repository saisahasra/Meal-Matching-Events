using Microsoft.AspNetCore.Components.Web;
using DDD_work.Services;
using DDD_work.Services.Auth; 
using DDD_work.Services.Match;
using DDD_work.Data; 

var builder = WebApplication.CreateBuilder(args); // this builds the web app

// add all the services we need
builder.Services.AddRazorPages(); // for regular web pages
builder.Services.AddServerSideBlazor(); 
builder.Services.AddSingleton<WeatherForecastService>(); // I wanna delete this but im scared
builder.Services.AddScoped<UserDataService>(); // gets user data
builder.Services.AddScoped<UserService>(); // handles user info
builder.Services.AddSingleton<MatchService>(); // for matching users
builder.Services.AddScoped<EventService>();
builder.Services.AddHttpClient(); // lets us make web calls

var app = builder.Build(); // the app is ready

// set up how the app handles things
if (!app.Environment.IsDevelopment()) // if we're not in development mode
{
    app.UseExceptionHandler("/Error"); // show an error page if things break
    // some security stuff for when it's live
    app.UseHsts();
}

app.UseHttpsRedirection(); // force https
app.UseStaticFiles(); // serve up our static files like css

app.UseRouting(); // figure out the routes

app.MapBlazorHub(); // for the blazor connection
app.MapFallbackToPage("/_Host"); // if nothing else matches, go here

app.Run(); // start the app running