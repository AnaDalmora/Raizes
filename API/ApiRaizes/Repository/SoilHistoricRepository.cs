using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;

namespace ApiRaizes.Repository
{
    public class SoilHistoricRepository : ISoilHistoricRepository
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SoilHistoricEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SoilHistoricEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(SoilHistoricInsertDTO harvest)
        {
            throw new NotImplementedException();
        }

        public Task Update(SoilHistoricEntity harvest)
        {
            throw new NotImplementedException();
        }
    }
}
