
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCarter();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AddMarten(opts => opts.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!)).UseLightweightSessions();

var app = builder.Build();
app.MapGet("/", () => "Hello world");
app.MapCarter();

app.Run();
