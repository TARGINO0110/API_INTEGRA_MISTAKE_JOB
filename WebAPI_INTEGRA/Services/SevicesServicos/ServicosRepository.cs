using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_INTEGRA.Models;

namespace WebAPI_INTEGRA.Services.SevicesServicos
{
    public class ServicosRepository : IServicosRepository
    {
        public readonly IConfiguration _configuration;

        // ******** ACESSO AO BANCO SOBRE O ARQUIVO JSON 'appsettings.json', CONCEDIDO PELA INTERFACE 'IConfiguration' DA CLASSE 'Startup' ********
        public ServicosRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ******** ACESSO AO BANCO COM 'ConnectionString' NA CLASSE LOCAL ********

        //public string ConnectionString;
        //public ServicosRepository()
        //{
        //    ConnectionString = @"Data Source=Seu HostName;Initial Catalog=Seu Banco;Integrated Security=True";
        //}

        //public IDbConnection Connection
        //{
        //    //get { return new SqlConnection(ConnectionString); }
        //}

        public IDbConnection Connection
        {
            get { return new SqlConnection(_configuration.GetConnectionString("DefaultConnection")); }
            //get { return new OracleConnection(_configuration.GetConnectionString("DefaultConnection")); } UTILIZAR EM BANCO ORACLE
        }
        //OBS : PARA USO DOS BIND EM ORACLE TROCAR O [@ POR :] POR EXEMPO => sQuery = @ INSERT INTO TABELA (COLUNA1,COLUNA2) VALUES (:COLUNA1,:COLUNA2);

        public async Task<IEnumerable<Servicos>> GetAll()
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"SELECT * FROM SERVICOS";
                dbConnection.Open();
                var listaSql = await dbConnection.QueryAsync<Servicos>(sQuery);
                return listaSql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public async Task<Servicos> GetById(int id)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"SELECT * FROM SERVICOS WHERE ServicosId = @Id";
                dbConnection.Open();
                var listaIdSql = await dbConnection.QueryAsync<Servicos>(sQuery, new { Id = id });
                return (listaIdSql).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public void AddServicos(Servicos servicos)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"INSERT INTO SERVICOS (Protocolo,Descricao,TipoServico,Preco,DataServico) 
                                VALUES (@Protocolo,@Descricao,@TipoServico,@Preco,@DataServico)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, servicos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public void UpdateServicos(Servicos servicos)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"UPDATE SERVICOS SET Protocolo=@Protocolo,
                                                      Descricao=@Descricao,
                                                      TipoServico=@TipoServico,
                                                      Preco=@Preco,
                                                      DataServico=@DataServico
                                                      WHERE ServicosId = @ServicosId";
                dbConnection.Open();
                dbConnection.Query(sQuery, servicos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public void DeleteServicos(int id)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"DELETE FROM SERVICOS WHERE ServicosId = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }

    }
}
