using MyTest.Data;
using MyTest.Model.Configration;

var builder = WebApplication.CreateBuilder(args);
    
builder.Configuration
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services
    .AddSingleton(sp =>{
        var myDbConnectionString = new MyDbConnectionString();
        builder.Configuration.GetSection("ConnectionStrings").Bind(myDbConnectionString);
        if (myDbConnectionString != null)
        {
            return new MyDbContext(myDbConnectionString.ApplicationConnection);
        }
        else {
            throw new ApplicationException("Could not load Db context");
        }
        
    })
    .AddScoped<IAdminRepository, AdminRepository>()
    .AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(name: "api", pattern: "API/{controller}/{action=Index}");
});

app.Run();
