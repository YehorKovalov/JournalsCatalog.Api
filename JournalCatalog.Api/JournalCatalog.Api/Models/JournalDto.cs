namespace JournalCatalog.Api.Models;

public class JournalDto
{
    public Guid JournalId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool Attendance { get; set; }
}