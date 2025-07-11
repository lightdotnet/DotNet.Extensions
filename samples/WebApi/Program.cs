using Light.ActiveDirectory;
using Light.Extensions.DependencyInjection;
using Light.Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var executingAssembly = Assembly.GetExecutingAssembly();

builder.Host.ConfigureSerilog();

builder.Services.AddActiveDirectory(opt => opt.Name = "domain.local");
/*
builder.Services.AddMicrosoftGraph(opt =>
{
    opt.ClientSecret = "";
    opt.ClientId = "";
    opt.TenantId = "";
});
*/
builder.Services.AddFileGenerator();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();