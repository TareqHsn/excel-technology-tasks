using PatientInfo_Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AddapiServices
builder.Services.AddHttpClient<PatientApiService>();
builder.Services.AddScoped<DiseaseApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
        name: "api",
        pattern: "api/{controller=Patient}/{action=Create}/{id?}");
app.MapControllerRoute(
        name: "api",
        pattern: "api/{controller=Patient}/{action=Create}/{id?}");

app.Run();
