using JournalCatalog.Api.Data;
using JournalCatalog.Api.Helpers;
using JournalCatalog.Api.Models;
using JournalCatalog.Api.Services.Abstractions;

namespace JournalCatalog.Api.Services;

public class JournalService : BaseDataService, IJournalService
{
    private readonly JournalsStore _journalsStore;
    public JournalService(
        ILogger<BaseDataService> logger,
        JournalsStore journalsStore)
        : base(logger)
    {
        _journalsStore = journalsStore;
    }

    public AddJournalResponse<JournalDto> AddJournal(string fullName, DateTime date, bool attendance)
    {
        return ExecuteSafe(() =>
        {
            _logger.LogInformation($"{nameof(AddJournal)} ---> {nameof(fullName)} = {fullName}; {nameof(date)} = {date}; {nameof(attendance)} = {attendance};");
            var journalEntity = new Journal
            {
                JournalId = new Guid(),
                Attendance = attendance,
                Date = date,
                FullName = fullName
            };

            _journalsStore.Journals = _journalsStore.Journals.Append(journalEntity);

            return new AddJournalResponse<JournalDto>
            {
                Data = new JournalDto
                {
                    JournalId = journalEntity.JournalId,
                    Attendance = journalEntity.Attendance,
                    Date = date,
                    FullName = fullName
                }
            }; 
        });
    }

    public GetAllJournalsResponse<JournalDto> GetAllJournalsOrEmpty()
    {
        return ExecuteSafe(() =>
        {
            var journals = _journalsStore.Journals;
            _logger.LogInformation($"{nameof(GetAllJournalsOrEmpty)} ---> journals amount = {journals.Count()}");
            return new GetAllJournalsResponse<JournalDto>
            {
                Data = journals.Select(s => new JournalDto
                {
                    JournalId = s.JournalId,
                    Attendance = s.Attendance,
                    Date = s.Date,
                    FullName = s.FullName
                }).ToList()
            };
        });
    }

    public GetJournalByIdResponse<JournalDto> GetJournalByIdOrDefaultAsync(Guid journalId)
    {
        return ExecuteSafe(() =>
        {
            var result = _journalsStore.Journals.FirstOrDefault(f => f.JournalId == journalId);
            if (result == null)
            {
                _logger.LogInformation($"{nameof(GetJournalByIdOrDefaultAsync)} ---> Searched journal is null");
                return new GetJournalByIdResponse<JournalDto> {Data = null};
            }

            _logger.LogInformation(
                $"{nameof(GetJournalByIdOrDefaultAsync)} ---> Searched journal id: {result?.JournalId}");
            return new GetJournalByIdResponse<JournalDto>
            {
                Data = new JournalDto
                {
                    JournalId = result!.JournalId,
                    Attendance = result.Attendance,
                    Date = result.Date,
                    FullName = result.FullName
                }
            };
        });
    }

    public DeleteJournalByIdResponse<bool> DeleteJournalByIdAsync(Guid journalId)
    {
        return ExecuteSafe(() =>
        {
            var result = _journalsStore.Journals.ToList().Remove(new Journal { JournalId = journalId });
            _logger.LogInformation($"{nameof(DeleteJournalByIdAsync)} ---> result: {result}");
            return new DeleteJournalByIdResponse<bool> { Data = result };
        });
    }

    public UpdateJournalResponse<JournalDto> UpdateJournalByIdAsync(Guid journalId, string fullName, DateTime date, bool attendance)
    {
        return ExecuteSafe(() =>
        {
            _logger.LogInformation($"{nameof(UpdateJournalByIdAsync)} ---> {nameof(journalId)} = {journalId}; {nameof(fullName)} = {fullName}; {nameof(date)} = {date}; {nameof(attendance)} = {attendance};");
            var journalEntity = new Journal
            {
                JournalId = journalId,
                Attendance = attendance,
                Date = date,
                FullName = fullName
            };

            var searchedJournal = _journalsStore.Journals.FirstOrDefault(f => f.JournalId == journalId);
            if (searchedJournal == null)
            {
                _logger.LogInformation($"{nameof(UpdateJournalByIdAsync)} ---> Searched journal is null");
                return new UpdateJournalResponse<JournalDto> { Data = null };
            }

            searchedJournal.Attendance = attendance;
            searchedJournal.Date = date;
            searchedJournal.FullName = fullName;
            
            return new UpdateJournalResponse<JournalDto>
            {
                Data = new JournalDto
                {
                    JournalId = journalEntity.JournalId,
                    Attendance = journalEntity.Attendance,
                    Date = date,
                    FullName = fullName
                }
            }; 
        });
    }
}