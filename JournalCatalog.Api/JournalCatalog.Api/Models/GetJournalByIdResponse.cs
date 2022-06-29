namespace JournalCatalog.Api.Models;

public class GetJournalByIdResponse<TData>
{
    public TData? Data { get; set; }
}