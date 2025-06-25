using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class RawMaterialStockService : IRawMaterialStockService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            RawMaterialStockRepository _repository = new RawMaterialStockRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Colheita excluída com sucesso!"
            };
        }

        public async Task<RawMaterialStockGetAllResponse> GetAll()
        {
            RawMaterialStockRepository _repository = new RawMaterialStockRepository();
            return new RawMaterialStockGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<RawMaterialStockEntity> GetById(int id)
        {
            RawMaterialStockRepository _repository = new RawMaterialStockRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(RawMaterialStockInsertDTO rawMaterialStock)
        {
            RawMaterialStockRepository _repository = new RawMaterialStockRepository();
            await _repository.Insert(rawMaterialStock);
            return new MessageResponse
            {
                Message = "Colheita inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(RawMaterialStockEntity rawMaterialStock)
        {
            RawMaterialStockRepository _repository = new RawMaterialStockRepository();
            await _repository.Update(rawMaterialStock);
            return new MessageResponse
            {
                Message = "Colheita alterada com sucesso"
            };
        }
    }
}

