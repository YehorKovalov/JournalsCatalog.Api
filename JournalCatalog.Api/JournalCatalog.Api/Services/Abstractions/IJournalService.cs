using JournalCatalog.Api.Models;

namespace JournalCatalog.Api.Services.Abstractions;

public interface IJournalService
{
    AddJournalResponse<JournalDto> AddJournal(string fullName, DateTime date, bool attendance);

    GetAllJournalsResponse<JournalDto> GetAllJournalsOrEmpty();

    GetJournalByIdResponse<JournalDto> GetJournalByIdOrDefaultAsync(Guid journalId);

    DeleteJournalByIdResponse<bool> DeleteJournalByIdAsync(Guid journalId);

    UpdateJournalResponse<JournalDto> UpdateJournalByIdAsync(Guid journalId, string fullName, DateTime date, bool attendance);
}