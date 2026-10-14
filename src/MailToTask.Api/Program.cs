using System.Text.Json.Serialization;

using MailToTask.Api;
using MailToTask.Core;
using MailToTask.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IEmailAnalyzer, EmailAnalyzer>(client =>
{
    client.BaseAddress = new Uri("http://localhost:11434");
    client.Timeout = TimeSpan.FromMinutes(3);
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/analyze", async (AnalyzeRequest request, IEmailAnalyzer analyzer, CancellationToken ct) =>
{
    if (string.IsNullOrWhiteSpace(request.EmailText))
    {
        return Results.BadRequest("EmailText must not be empty."); // HTTP 400
    }

    EmailAnalysis result = await analyzer.AnalyzeAsync(request.EmailText, ct);
    return Results.Ok(result); // HTTP 200 + JSON
});

app.Run();
