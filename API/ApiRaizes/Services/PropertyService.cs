using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class PropertyService : IPropertyService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            PropertyRepository _repository = new PropertyRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Propriedade excluída com sucesso!"
            };
        }

        public async Task<PropertyGetAllResponse> GetAll()
        {
            PropertyRepository _repository = new PropertyRepository();
            return new PropertyGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<PropertyEntity> GetById(int id)
        {
            PropertyRepository _repository = new PropertyRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(PropertyInsertDTO property)
        {
            PropertyRepository _repository = new PropertyRepository();
            await _repository.Insert(property);
            return new MessageResponse
            {
                Message = "Propriedade inserida com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(PropertyEntity property)
        {
            PropertyRepository _repository = new PropertyRepository();
            await _repository.Update(property);
            return new MessageResponse
            {
                Message = "Propriedade alterada com sucesso"
            };
        }
    }

}
