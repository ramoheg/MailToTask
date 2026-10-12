namespace MailToTask.Infrastructure;

/// <summary>
/// Response from Ollama's <c>/api/chat</c> endpoint.
/// </summary>
/// <param name="Message">The model's answer.</param>
public record OllamaChatResponse(
    ChatMessage Message);
