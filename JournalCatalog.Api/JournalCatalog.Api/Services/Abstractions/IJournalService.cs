using JournalCatalog.Api.Models;

namespace JournalCatalog.Api.Services.Abstractions;

public interface IJournalService
{
    AddJournalResponse<JournalDto> AddJournal(string fullName, DateTime date, bool attendance);

    GetAllJournalsResponse<JournalDto> GetAllJournalsOrEmpty();

    GetJournalByIdResponse<JournalDto> GetJournalByIdOrDefault(Guid journalId);

    DeleteJournalByIdResponse<bool> DeleteJournalById(Guid journalId);

    UpdateJournalResponse<JournalDto> UpdateJournalById(Guid journalId, string fullName, DateTime date, bool attendance);
}