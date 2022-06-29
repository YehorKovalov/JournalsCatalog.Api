namespace JournalCatalog.Api.Helpers;

public class BaseDataService
{
    public BaseDataService(ILogger<BaseDataService> logger)
    {
        _logger = logger;
    }

    public ILogger<BaseDataService> _logger { get; } = null!;
    
    protected TResult ExecuteSafe<TResult>(Func<TResult> action)
    {
        try
        {
            return action.Invoke();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }
}