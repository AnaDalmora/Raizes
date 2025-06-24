using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using meuprimeirocrud.DTO;
using meuprimeirocrud.Entity;

namespace meuprimeirocrud.Contracts.Repository
{
    public interface IInsumoRepository
    {
        Task<IEnumerable<InsumoEntity>> GetAll();

        Task<InsumoEntity> GetById(int id);

        Task Insert (InsumoInsertDTO insumo);

        Task Delete(int id);

        Task Update (InsumoEntity insumo);

    }
}
