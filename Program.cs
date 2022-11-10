using MyFirstWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

/*Registering the service which we created for dependency injection
  There are 3 lifetime for the instance created:
    Singletone
    Transient
    Scoped */
//This code will add the service created to the dependency injection system.
builder.Services.AddScoped<ILoggerService, LoggerService>(); //The Syntax for registering the service is <Interface, Implementation(class)>

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
