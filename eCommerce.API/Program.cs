using eCommerce.API.Middlewares;
using eCommerce.IoC.Dependency;

var builder = WebApplication.CreateBuilder(args);

//Add dependency injection
builder.Services.AddServices();

//Add controllers to the service collection
builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Map controllers to endpoints
app.MapControllers();

app.Run();
