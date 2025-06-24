
using System.Security.Cryptography.X509Certificates;
using Dapper;
using meuprimeirocrud.Contracts.Repository;
using meuprimeirocrud.DTO;
using meuprimeirocrud.Entity;
using meuprimeirocrud.InfraEstructure;
using MySql.Data.MySqlClient;

namespace meuprimeirocrud.Repository
{
    public class InsumoRepository : IInsumoRepository
    {
        public async Task<IEnumerable<InsumoEntity>> GetAll()
        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                        SELECT ID AS {nameof(InsumoEntity.Id)},
                                Nome AS {nameof(InsumoEntity.Nome)},
                                Descricao AS{nameof(InsumoEntity.Descricao)},
                                Tipo AS{nameof(InsumoEntity.Tipo)}
                                FROM INSUMO
                    ";


                var insumolist = await con.QueryAsync<InsumoEntity>(sql);
                return insumolist;
            }

        }
        public async Task Insert(InsumoInsertDTO insumo)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO INSUMO (NOME)
                            VALUE (@Nome)
            ";

            await _connection.Execute(sql, insumo);


        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM INSUMO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<InsumoEntity> GetById(int id)

        {
            Connection _connection = new Connection();

            using (MySqlConnection con = _connection.GetConnection())
            {
                 

                string sql = @$"
                        SELECT ID AS {nameof(InsumoEntity.Id)},
                                Nome AS {nameof(InsumoEntity.Nome)},
                                Descricao AS{nameof(InsumoEntity.Descricao)},
                                Tipo AS{nameof(InsumoEntity.Tipo)}
                                 FROM INSUMO
                                 WHERE ID = @id

            ";
                InsumoEntity insumo = await con.QueryFirstAsync<InsumoEntity>(sql, new { id });
                return insumo;

            }



        }
        public async Task Update(InsumoEntity insumo)
        {
            Connection _connection = new Connection();

            string sql = @"
                UPDATE INSUMO
                   SET NOME = @Nome
                 WHERE ID = @Id
            ";

            await _connection.Execute(sql, insumo);
        }

    }
}