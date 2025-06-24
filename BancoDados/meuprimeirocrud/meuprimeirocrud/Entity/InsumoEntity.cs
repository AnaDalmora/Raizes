using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meuprimeirocrud.Entity
{
    public class InsumoEntity
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public string? Descricao { get; set; }
        public string? Pessoa { get; set; }
        public string? Tipo { get; set; }
       
    }

}
//Id int AI PK 
//PlantioId int 
//InsumoId int 
//Quantidade decimal(10,2) 
//DataAplicacao date
 