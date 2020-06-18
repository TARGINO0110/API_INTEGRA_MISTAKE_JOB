using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_INTEGRA.Models;

namespace WebAPI_INTEGRA.Services.ServicesFuncionario
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        public readonly IConfiguration _configuration;

        // ******** ACESSO AO BANCO SOBRE O ARQUIVO JSON 'appsettings.json', CONCEDIDO PELA INTERFACE 'IConfiguration' DA CLASSE 'Startup' ********
        public FuncionarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ******** ACESSO AO BANCO COM 'ConnectionString' NA CLASSE LOCAL ********

        //public string ConnectionString;
        //public FuncionarioRepository()
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
        }

        public IEnumerable<Funcionario> GetAll()
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"SELECT * FROM FUNCIONARIO";
                dbConnection.Open();
                return dbConnection.Query<Funcionario>(sQuery);
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

        public Funcionario GetById(int id)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"SELECT * FROM FUNCIONARIO WHERE FuncionarioId = @Id";
                dbConnection.Open();
                return dbConnection.Query<Funcionario>(sQuery, new { Id = id }).FirstOrDefault();
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

        public void AddFuncionario(Funcionario funcionario)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"INSERT INTO FUNCIONARIO (NomeFuncionario,FuncaoFunc,CPF,Salario) 
                                VALUES (@NomeFuncionario,@FuncaoFunc,@CPF,@Salario)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, funcionario);
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

        public void UpdateFuncionario(Funcionario funcionario)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"UPDATE FUNCIONARIO SET NomeFuncionario=@NomeFuncionario,
                                                         FuncaoFunc=@FuncaoFunc,
                                                         CPF=@CPF,
                                                         Salario=@Salario
                                                         WHERE FuncionarioId = @FuncionarioId";

                dbConnection.Open();
                dbConnection.Query(sQuery, funcionario);
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

        public void DeleteFuncionario(int id)
        {
            using IDbConnection dbConnection = Connection;
            try
            {
                string sQuery = @"DELETE FROM FUNCIONARIO WHERE FuncionarioId = @Id";
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
