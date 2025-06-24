using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meuprimeirocrud.Entity
{
    public class PlantioInsumoEntity
    {
        public int ? Id   { get; set; }
        public string? PlantioId  { get; set; }
        public string? InsumoId  { get; set; }
        public double? Quantidade { get; set; }
        public DateTime? DataAplicacao { get; set; }

    }
}
//Id int AI PK 
//PlantioId int 
//InsumoId int 
//Quantidade decimal(10,2) 
//DataAplicacao date