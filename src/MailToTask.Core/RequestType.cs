namespace MailToTask.Core;

/// <summary>
/// What kind of request a customer email contains.
/// </summary>
public enum RequestType
{
    Repair,      // something is broken
    Quote,       // customer wants a price for new work
    Appointment, // book, move or cancel an appointment
    Maintenance, // regular service, e.g. yearly boiler check
    Complaint,   // unhappy with past work or invoice
    Question,    // general question
    Other        // anything that doesn't fit or spam
}
