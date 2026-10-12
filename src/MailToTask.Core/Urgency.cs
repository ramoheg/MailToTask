namespace MailToTask.Core;

/// <summary>
/// How quickly a request needs a response.
/// </summary>
public enum Urgency
{
    Low,      // can wait a week
    Normal,   // within 1-2 working days 
    High,     // same day
    Emergency // immediately
}
