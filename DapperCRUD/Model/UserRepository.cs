using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUD.Model
{
    /// <summary>
    /// UserRepository for code functions for our CRUD application
    /// </summary>
    public class UserRepository
    {
        private string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public void Add(User user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlQuery = @"INSERT INTO [user] (Name,Address) VALUES (@Name,@Address)";
                dbConnection.Open();
                dbConnection.Execute(sqlQuery, user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlQuery = @"SELECT * FROM [user]";
                dbConnection.Open();
                return dbConnection.Query<User>(sqlQuery);
            }
        }

        public User GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlQuery = @"SELECT * FROM [user] WHERE UId=@Id";
                dbConnection.Open();
                return dbConnection.Query<User>(sqlQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlQuery = @"DELETE FROM [user] WHERE UId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sqlQuery, new { Id = id });
            }
        }

        public void Update(User user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlQuery = @"UPDATE [user] SET Name=@Name, Address=@Address WHERE UId=@UId";
                dbConnection.Open();
                dbConnection.Query(sqlQuery, user);
            }
        }
    }
}
