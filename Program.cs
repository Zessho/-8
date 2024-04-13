using FinanceAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*builder.Services.AddEndpointsApiExplorer();*/
builder.Services.AddMvc(mvc => { mvc.EnableEndpointRouting = false; });
builder.Services.AddSingleton<ApplicationContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
}*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controler = App}/{action =Index}/{id?}");
    routes.MapRoute("NotFound", "{*url}",
        new { controller = "App", action = "RedirectToMain" });

});

app.MapControllers();

app.Run();
