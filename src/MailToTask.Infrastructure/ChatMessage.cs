namespace MailToTask.Infrastructure;

/// <summary>
/// A single message in chat with the AI model.
/// </summary>
/// <param name="Role">Who wrote the message: "system", "user" or "assistant".</param>
/// <param name="Content">The text of the message.</param>
public record ChatMessage(
    string Role, string Content);
