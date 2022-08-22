using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.Authority = "https://login.microsoftonline.com/afaa35f0-fb8b-4955-b180-a8b270081ff2/v2.0";
        options.ClientId = "df05fc5b-f702-4e3f-bc06-9de384f00875";
        options.ResponseType = "code";
        options.SaveTokens = true;
        options.ClientSecret = "_0H8Q~9LryQ9vUlVzhCA0D7BPA8f7S3TTbFgQcHm";
    });

var app = builder.Build();

//application/client ID df05fc5b-f702-4e3f-bc06-9de384f00875
//Auth endpoint https://login.microsoftonline.com/afaa35f0-fb8b-4955-b180-a8b270081ff2/oauth2/v2.0/authorize

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();