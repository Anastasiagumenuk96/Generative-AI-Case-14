using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddLocalization(options => options.ResourcesPath = "Resources");

services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture("uk-UA");
    options.AddSupportedUICultures("en-US", "uk-UA");
    options.FallBackToParentUICultures = true;
    options.RequestCultureProviders.Clear();
});

services.AddControllersWithViews()
        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        .AddDataAnnotationsLocalization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseRequestLocalization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
