using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using ApiRaizes.Response;

namespace ApiRaizes.Services
{
    public class UserService: IUserService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            UserRepository _repository = new UserRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Usuário excluído com sucesso!"
            };
        }

        public async Task<UserGetAllResponse> GetAll()
        {
            UserRepository _repository = new UserRepository();
            return new UserGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }
        public async Task<UserEntity> GetById(int id)
        {
            UserRepository _repository = new UserRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(UserInsertDTO user)
        {
            UserRepository _repository = new UserRepository();
            await _repository.Insert(user);
            return new MessageResponse
            {
                Message = "Usuário inserido com sucesso!"
            };

        }

        public async Task<MessageResponse> Update(UserEntity user)
        {
            UserRepository _repository = new UserRepository();
            await _repository.Update(user);
            return new MessageResponse
            {
                Message = "Usuário alterado com sucesso"
            };
        }
    }
}
