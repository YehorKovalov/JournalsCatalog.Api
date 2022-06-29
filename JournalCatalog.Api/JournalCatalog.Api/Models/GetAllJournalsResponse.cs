namespace JournalCatalog.Api.Models;

public class GetAllJournalsResponse<TData>
{
    public IEnumerable<TData> Data { get; set; } = null!;
}