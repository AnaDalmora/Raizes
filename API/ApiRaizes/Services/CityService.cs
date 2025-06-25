using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class CityService : ICityService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            CityRepository _repository = new CityRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Cidade excluída com sucesso!"
            };
        }

        public async Task<CityGetAllResponse> GetAll()
        {
            CityRepository _repository = new CityRepository();
            return new CityGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<CityEntity> GetById(int id)
        {
            CityRepository _repository = new CityRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(CityInsertDTO city)
        {
            CityRepository _repository = new CityRepository();
            await _repository.Insert(city);
            return new MessageResponse
            {
                Message = "Cidade inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(CityEntity city)
        {
            CityRepository _repository = new CityRepository();
            await _repository.Update(city);
            return new MessageResponse
            {
                Message = "Cidade alterada com sucesso"
            };
        }
    }
}

