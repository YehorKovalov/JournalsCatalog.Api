namespace JournalCatalog.Api.Data;

public class JournalsStore
{
    public IEnumerable<Journal> Journals { get; set; }

    public JournalsStore() => Journals = GetJournals();

    private IEnumerable<Journal> GetJournals(int journalAmount = 20)
    {
        var random = new Random();
        var journals = new List<Journal>();
        for (var i = 0; i < 20; i++)
        {
            journals.Add(new Journal
            {
                JournalId = Guid.NewGuid(),
                Attendance = i % 2 == 0,
                FullName = $"Test Journal Full Name {i}",
                Date = DateTime.UtcNow.AddDays(random.Next(20))
            });
        }

        return journals;
    }
}