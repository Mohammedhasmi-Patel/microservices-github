
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCarter();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(Program).Assembly));

var app = builder.Build();
app.MapCarter();

app.Run();
