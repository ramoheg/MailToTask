namespace MailToTask.Api;

/// <summary>
/// Request body for POST /api/analyze.
/// </summary>
/// <param name="EmailText">The full text of the customer email.</param>
public record AnalyzeRequest(string EmailText);
