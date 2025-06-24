using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using meuprimeirocrud.Contracts.Repository;
using meuprimeirocrud.DTO;
using meuprimeirocrud.Entity;
using meuprimeirocrud.InfraEstructure;
using MySql.Data.MySqlClient;

namespace meuprimeirocrud.Repository
{
    public class PlantioInsumoRepository : IPlantioInsumoRepository
    {
        public async Task Delete(int id)
        {

            Connection _connection = new Connection();
            string sql = "DELETE FROM PLANTIOINSUMO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<PlantioInsumoEntity>> GetAll()
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                        SELECT ID AS {nameof(PlantioInsumoEntity.Id)},
                                PlantioId AS {nameof(PlantioInsumoEntity.PlantioId)},
                                InsumoId AS {nameof(PlantioInsumoEntity.InsumoId)},
                                Quantidade AS {nameof(PlantioInsumoEntity.Quantidade)},
                                DataAplicacao AS {nameof(PlantioInsumoEntity.DataAplicacao)}
                                FROM PLANTIOINSUMO
                    ";


                var insumoPlantiolist = await con.QueryAsync<PlantioInsumoEntity>(sql);
                return insumoPlantiolist;
            }
        }

        public async Task<PlantioInsumoEntity> GetById(int id)
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {


                string sql = @$"
                     SELECT ID AS {nameof(PlantioInsumoEntity.Id)},
                                PlantioId AS {nameof(PlantioInsumoEntity.PlantioId)},
                                InsumoId AS {nameof(PlantioInsumoEntity.InsumoId)},
                                Quantidade AS {nameof(PlantioInsumoEntity.Quantidade)},
                                DataAplicacao AS {nameof(PlantioInsumoEntity.DataAplicacao)}
                                FROM PLANTIOINSUMO    
                                    WHERE ID = @id

            ";
                var insumo = await con.QueryFirstAsync<PlantioInsumoEntity>(sql, new { id });
                return insumo;

            }

        }

        public async Task Insert(PlantioInsumoInsertDTO insumoplantio)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO PLANTIOINSUMO (PlantioId, InsumoId, Quantidade, DataAplicacao)
                            VALUE (@PlantioId, @InsumoId, @Quantidade, @DataAplicacao)
            ";

            await _connection.Execute(sql, insumoplantio);
        }

        public  async Task Update(PlantioInsumoEntity insumoplantio)
        {
            Connection _connection = new Connection();

            string sql = @"
                UPDATE PLANTIOINSUMO
                   SET Quantidade = @Quantidade
                 WHERE ID = @Id
            ";

            await _connection.Execute(sql, insumoplantio);
        }
    }


}
//Id int AI PK 
//PlantioId int 
//InsumoId int 
//Quantidade decimal(10,2) 
//DataAplicacao date