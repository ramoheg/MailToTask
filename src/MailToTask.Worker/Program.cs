using MailToTask.Core;
using MailToTask.Infrastructure;

const string exampleEmail = """
    Betreff: Wasser tropft unter dem Lavabo

    Grüezi

    Seit gestern Abend tropft bei uns im Badezimmer Wasser unter dem Lavabo hervor.
    Wir haben einen Kübel darunter gestellt, aber es wird immer mehr.
    Könnte jemand morgen oder übermorgen vorbeikommen?

    Freundliche Grüsse
    Sandra Keller
    Seestrasse 12, 8820 Wädenswil
    079 123 45 67
    """;

try
{
    Console.WriteLine("Analyzing email...");

    var emailAnalyzer = new EmailAnalyzer();
    EmailAnalysis result = await emailAnalyzer.AnalyzeAsync(exampleEmail);

    Console.WriteLine($"Customer: {result.Customer}");
    Console.WriteLine($"Type:     {result.Type}");
    Console.WriteLine($"Urgency:  {result.Urgency}");
    Console.WriteLine($"Reply:{System.Environment.NewLine}{result.SuggestedReply}");
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"Could not reach Ollama. Is it running? ({ex.Message})");
}
catch (System.Text.Json.JsonException ex)
{
    Console.WriteLine($"The AI answer was not vaild JSON: {ex.Message}");
}
