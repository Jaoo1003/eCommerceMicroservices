using eCommerce.API.Middlewares;
using eCommerce.Core.Mappers;
using eCommerce.IoC.Dependency;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add dependency injection
builder.Services.AddServices();

//Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions
    (
        options =>
        {
            options.JsonSerializerOptions.Converters.Add
            (new JsonStringEnumConverter());
        }
    );

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(ApplicationUserMappingProfile).Assembly);
});

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
