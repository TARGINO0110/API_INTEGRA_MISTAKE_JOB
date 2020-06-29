using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_INTEGRA.Models;

namespace WebAPI_INTEGRA.Services.ServicesEmpresa
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public readonly IConfiguration _configuration;

        // ******** ACESSO AO BANCO SOBRE O ARQUIVO JSON 'appsettings.json', CONCEDIDO PELA INTERFACE 'IConfiguration' DA CLASSE 'Startup' ********
        public EmpresaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ******** ACESSO AO BANCO COM 'ConnectionString' NA CLASSE LOCAL ********

        //public string ConnectionString;
        //public EmpresaRepository()
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

        public async Task<IEnumerable<Empresa>> GetAll()
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"SELECT * FROM EMPRESA";
                dbConnection.Open();
                var listaSql = await dbConnection.QueryAsync<Empresa>(sQuery);
                return (listaSql);
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

        public async Task<Empresa> GetById(int id)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"SELECT * FROM EMPRESA WHERE EmpresaId = @Id";
                dbConnection.Open();
                var listaIdSql = await dbConnection.QueryAsync<Empresa>(sQuery, new { Id = id });
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

        public void AddEmpresa(Empresa empresa)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"INSERT INTO EMPRESA (RazaoSocial,NomeFantasia,CNPJ,TipoPJ,DataAbertura) 
                                VALUES (@RazaoSocial,@NomeFantasia,@CNPJ,@TipoPJ,@DataAbertura)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, empresa);
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

        public void UpdateEmpresa(Empresa empresa)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"UPDATE EMPRESA SET RazaoSocial=@RazaoSocial,
                                                           NomeFantasia=@NomeFantasia,
                                                           CNPJ=@CNPJ,
                                                           TipoPJ=@TipoPJ,
                                                           DataAbertura=@DataAbertura
                                                           WHERE EmpresaId = @EmpresaId";

                dbConnection.Open();
                dbConnection.Query(sQuery, empresa);
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

        public void DeleteEmpresa(int id)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"DELETE FROM EMPRESA WHERE EmpresaId = @Id";
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
