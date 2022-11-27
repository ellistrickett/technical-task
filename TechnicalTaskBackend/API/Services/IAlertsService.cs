using API.Context;

namespace API.Services
{
    public interface IAlertsService
    {
        Task<List<Alert>> GetAllAsync();
    }
}
