using eOrder.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddAndConfigureControllers()
    .AddDocumentation()
    .AddDbConnections(builder.Configuration)
    .AddUseCases()
    .AddRepositories();

var app = builder.Build();


app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
