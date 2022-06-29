namespace JournalCatalog.Api.Data;

public class Journal
{
    public Guid JournalId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool Attendance { get; set; }   
}