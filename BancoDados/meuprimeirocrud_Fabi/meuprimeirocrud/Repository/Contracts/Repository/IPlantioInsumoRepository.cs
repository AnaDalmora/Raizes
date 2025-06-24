using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using meuprimeirocrud.DTO;
using meuprimeirocrud.Entity;

namespace meuprimeirocrud.Contracts.Repository
{
    public interface  IPlantioInsumoRepository
    {
        Task<IEnumerable<PlantioInsumoEntity>> GetAll();

        Task<PlantioInsumoEntity> GetById(int id);

        Task Insert(PlantioInsumoInsertDTO insumo);

        Task Delete(int id);

        Task Update(PlantioInsumoEntity insumo);
    }
}
