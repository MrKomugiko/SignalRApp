using Microsoft.AspNetCore.ResponseCompression;
using SignalRApp.Server.Data;
using SignalRApp.Server.Hubs;

//Console.WriteLine("Environment.ProcessPath = " + Environment.ProcessPath);
//Console.WriteLine("Path.GetDirectoryName(Environment.ProcessPath) = " + Path.GetDirectoryName(Environment.ProcessPath));

//WebApplicationOptions options = new()
//{
//    ContentRootPath = Path.GetDirectoryName(Environment.ProcessPath),
//};
//var builder = WebApplication.CreateBuilder(options);
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opt =>
{
    opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
    {
        "application/octet-stream"
    });
});

builder.Services.AddSingleton(typeof(Storage));
builder.Services.AddSingleton<NotificationHub>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseResponseCompression();
app.MapHub<NotificationHub>("/NotificationHub");

app.Run();
