using MailToTask.Core;
using MailToTask.Infrastructure;

try
{
    Console.WriteLine("Analyzing email...");

    var analyzer = new EmailAnalyzer();

    var expected = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "expected.csv"))
        .Skip(1)
        .Select(line => line.Split(';'))
        .ToDictionary(c => c[0], c => (Type: Enum.Parse<RequestType>(c[2]),
            Urgency: Enum.Parse<Urgency>(c[3])));

    int passed = 0;
    foreach ((string? file, (RequestType Type, Urgency Urgency) exp) in expected)
    {
        string text = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "emails", file));
        var result = await analyzer.AnalyzeAsync(text);
        bool ok = result.Type == exp.Type && result.Urgency == exp.Urgency;

        if (ok)
        {
            passed++;
        }

        Console.WriteLine($"{(ok ? "OK" : "Fail")} {file}: got {result.Type}/{result.Urgency}, " +
            $"expected {exp.Type}/{exp.Urgency}, customer '{result.Customer}'");
    }

    Console.WriteLine();
    Console.WriteLine($"{passed}/{expected.Count} passed");
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"Could not reach Ollama. Is it running? ({ex.Message})");
}
catch (System.Text.Json.JsonException ex)
{
    Console.WriteLine($"The AI answer was not vaild JSON: {ex.Message}");
}
