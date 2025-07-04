﻿using Dapper;
using MeuPrimeiroCrud.Contracts.Repository;
using MeuPrimeiroCrud.DTO;
using MeuPrimeiroCrud.Entity;
using MeuPrimeiroCrud.InfraEstructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroCrud.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
      
        public async Task<IEnumerable<cidadeEntity>> GetAll()
        {
           Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(cidadeEntity.Id)},
                           Nome AS {nameof(cidadeEntity.Nome)},
                           Estado AS {nameof(cidadeEntity.Estado)},
                           Pais AS {nameof(cidadeEntity.Pais)}
                    FROM cidade
                ";

                IEnumerable<cidadeEntity> citylist = await con.QueryAsync<cidadeEntity>(sql);

                return citylist;
            }
        }

        public async Task Insert(CidadeInsertDTO cidade)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO CIDADE (NOME,ESTADO,PAIS,)
                            VALUE(@Nome,@Estado,@Pais)
            ";
           
            await _connection.Execute(sql,cidade);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM CIDADE WHERE ID = @id";

            await _connection.Execute(sql, new {id});
        }

        public async Task<cidadeEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(cidadeEntity.Id)},
                           Nome AS {nameof(cidadeEntity.Nome)},
                           Estado AS {nameof(cidadeEntity.Estado)},
                           Pais AS {nameof(cidadeEntity.Pais)}
                    FROM cidade
                    WHERE ID = @id
                ";

                cidadeEntity cidade = await con.QueryFirstAsync<cidadeEntity>(sql, new { id });
                return cidade;
            }

        }

        public async Task Update(cidadeEntity cidade)
        {
            Connection _connection = new Connection();
            string sql = @"
                UPDATE CIDADE 
                    SET Nome = @Nome
                WHERE ID = @id
            ";

            await _connection.Execute(sql, cidade);
        }


    }
}
