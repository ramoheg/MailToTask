namespace MailToTask.Infrastructure;

/// <summary>
/// Request body for Ollama's <c>/api/chat</c> endpoint.
/// </summary>
/// <param name="Model">Name of Ollama model.</param>
/// <param name="Messages">The conversation: sytem instructions followed by the user message.</param>
/// <param name="Format">Set to "json" to force the model to answer with valid JSON.</param>
/// <param name="Stream">False to recive the complete answer in one response instead of word by word.</param>
public record OllamaChatRequest(
    string Model, List<ChatMessage> Messages, string Format, bool Stream, OllamaOptions Options);
