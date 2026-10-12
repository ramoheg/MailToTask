namespace MailToTask.Core;

/// <summary>
/// Extracts structured information from a customer email.
/// </summary>
public interface IEmailAnalyzer
{
    /// <summary>
    /// Analyzes given email and returns the extracted information.
    /// </summary>
    /// <param name="emailText">The text body of the customer email.</param>
    /// <param name="cancellationToken">Cancels the request, e.g. when the app shuts down.</param>
    /// <returns>The structured analysis of the email.</returns>
    public Task<EmailAnalysis> AnalyzeAsync(string emailText, CancellationToken cancellationToken = default);
}
