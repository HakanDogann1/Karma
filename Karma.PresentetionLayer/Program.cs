using Karma.DataAccessLayer.Context;
using Karma.EntityLayer.Concrete;
using Karma.PresentetionLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KarmaDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
CustomExtensions.CustomConigurationExtensions(builder.Services);
var app = builder.Build();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
