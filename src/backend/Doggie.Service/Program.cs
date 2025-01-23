using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/system", () =>
{
    var machineName = Environment.MachineName;
    var userName = Environment.UserName;
    var osVersion = Environment.OSVersion;
    var processorCount = Environment.ProcessorCount;
  
    return TypedResults.Ok(new
    {
        MachineName = machineName,
        UserName = userName,
        OSVersion = osVersion.ToString(),
        ProcessorCount = processorCount
    });
});


app.Run();
