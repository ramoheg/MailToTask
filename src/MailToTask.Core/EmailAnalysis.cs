namespace MailToTask.Core;

/// <summary>
/// The structured result the AI extracted from one customer email.
/// </summary>
/// <param name="Customer">Customer or Company name.</param>
/// <param name="Type">Type of request the customer has.</param>
/// <param name="Urgency">How quickly the request needs a response.</param>
/// <param name="SuggestedReply">Suggested response for the customer email.</param>
public record EmailAnalysis(string Customer, RequestType Type, Urgency Urgency, string SuggestedReply);
