using Dapper;
using NascimentoSoftware.Livraria.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NascimentoSoftware.Livraria.Infraestrutura.Infraestrutura
{
    public class AuthorRepository : IRepository<Models.Author>
    {
        public string GetConnection()
        {
            var connection = $@"Server=DESKTOP-2L16HEL\SQLEXPRESS;Database=BookStore;Trusted_Connection=True;MultipleActiveResultSets=true";
            return connection;
        }
        public int add(Author objeto)
        {
            var param = new DynamicParameters();
            
            param.Add("Guid", objeto.Guid);
            param.Add("FirstName", objeto.FirstName);
            param.Add("LastName", objeto.LastName);

            var query = $@"INSERT INTO Authors(Guid, FirstName, LastName) VALUES (@Guid, @FirstName, @LastName)";
           

            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Execute(query, param: param, commandType: System.Data.CommandType.Text);
            }
        }

        public int delete(int id)
        {
            var param = new DynamicParameters();
            param.Add("id", id);


            var query = $@"delete from Authors where Guid = @id";
           

            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Execute(query, param: param, commandType: System.Data.CommandType.Text);
            }
        }

        public List<Author> GetAll()
        {
            var query = $@"select Id, Guid, FirstName, LastName from Authors";
            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Query<Author>(query, commandType: System.Data.CommandType.Text).ToList();
            }
        }

        public Author GetOne(int id)
        {
            var param = new DynamicParameters();
            param.Add("id", id);

            var query = $@"select Id, Guid, FirstName, LastName from Authors where Guid = @id";
           
            using (var sql = new SqlConnection(GetConnection()))
            {
                return sql.Query<Author>(query, param: param, commandType: System.Data.CommandType.Text).FirstOrDefault();
            }
        }

        public int update(Author objeto)
        {
            var param = new DynamicParameters();
            param.Add("FirstName", objeto.FirstName);
            param.Add("LastName", objeto.LastName);
            param.Add("Guid", objeto.Guid);

            var query = $@"Update Authors SET FirstName = @FirstName, LastName = @LastName WHERE Guid = @guid";
            
            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Execute(query, param: param, commandType: System.Data.CommandType.Text);
            }

        }
    }
}
