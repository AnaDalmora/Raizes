using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meuprimeirocrud.DTO
{
    public class PlantioInsumoInsertDTO
    {
        //Id int AI PK 
        //PlantioId int 
        //InsumoId int 
        //Quantidade decimal(10,2) 
        public int PlantioId {  get; set; }
        public int InsumoId { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAplicacao { get; set; }
    }
}
//Id int AI PK 
//PlantioId int 
//InsumoId int 
//Quantidade decimal(10,2) 
//DataAplicacao date