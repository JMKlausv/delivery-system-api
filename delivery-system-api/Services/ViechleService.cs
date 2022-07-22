using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Domain.Services;
using delivery_system_api.Domain.Services.Communications;

namespace delivery_system_api.Services
{
    public class ViechleService : IViechleService
    {
        private readonly IViechleRepository _viechleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ViechleService(IViechleRepository viechleRepository , IUnitOfWork unitOfWork)
        {
            _viechleRepository = viechleRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ViechleResponse> AddViechleAsync(Viechle viechle)
        {
            try
            {
                await _viechleRepository.AddAsync(viechle);
                await _unitOfWork.CompleteAsync();
                return new ViechleResponse(viechle);

            }
            catch (Exception ex)
            {
               

                return new ViechleResponse($"could not add viechle : {ex.Message}");
            }
        }

        public async Task<ViechleResponse> DeleteViechleAsync(int viechleId)
        {
            var existingViechle = await _viechleRepository.GetByIdAsync(viechleId);
            if (existingViechle == null)
            {
                return new ViechleResponse("Viechle not found!");
            }
            try
            {
                await _viechleRepository.Delete(existingViechle);
                await _unitOfWork.CompleteAsync();
                return new ViechleResponse(true, string.Empty, null);
            }
            catch (Exception ex)
            {
                return new ViechleResponse(ex.Message);
            }
        }

        public async Task<Viechle> GetViechleById(int id)
        {
            var viechle = await _viechleRepository.GetByIdAsync(id);
            if (viechle == null)
            {
                throw new Exception("Viechle Not found");
            }
            return viechle;
        }

        public Task<IEnumerable<Viechle>> GetViechlesAsync()
        {
            return _viechleRepository.ListAsync();
        }

        public async Task<ViechleResponse> UpdateViechleAsync(Viechle viechle)
        {
            var existingViechle = await _viechleRepository.GetByIdAsync(viechle.Id);
            if (existingViechle == null)
            {
                return new ViechleResponse("Viechle not found!");
            }
            try
            {
                await _viechleRepository.Update(viechle);
                await _unitOfWork.CompleteAsync();
                return new ViechleResponse(viechle);

            }
            catch (Exception ex)
            {

                return new ViechleResponse($"Could not update viechle : {ex.Message}");
            }
        }
    }
}
 