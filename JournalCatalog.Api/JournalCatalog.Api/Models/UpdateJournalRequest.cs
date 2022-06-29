namespace JournalCatalog.Api.Models;

public class UpdateJournalRequest
{
    public string FullName { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool Attendance { get; set; }
}