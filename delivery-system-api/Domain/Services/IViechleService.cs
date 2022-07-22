using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services.Communications;
namespace delivery_system_api.Domain.Services{
    public interface IViechleService
    {

        Task<IEnumerable<Viechle>>GetViechlesAsync();
        Task<Viechle>GetViechleById(int id);  
        Task<ViechleResponse> AddViechleAsync(Viechle viechle);
        Task<ViechleResponse> UpdateViechleAsync(Viechle viechle);
        Task<ViechleResponse> DeleteViechleAsync(int viechleId);
    }
}
