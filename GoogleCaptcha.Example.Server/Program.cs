using GoogleCaptcha.Example.Server.Data;
using GoogleCaptchaComponent;
using GoogleCaptchaComponent.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddGoogleCaptcha(options =>
{
    options.DefaultVersion = CaptchaConfiguration.Version.V3;
    options.V3SiteKey = "Your V3 Site key from Google developer Console";
    options.V2SiteKey = "Your V2 site key from Google developer Console";
    options.DefaultTheme = CaptchaConfiguration.Theme.Dark;
});

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
