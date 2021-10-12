using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NascimentoSoftware.Livraria.Infraestrutura.Infraestrutura
{
    public class BookRepository : IRepository<Models.Book>
    {
        public string GetConnection()
        {
            var connection = $@"Server=DESKTOP-2L16HEL\SQLEXPRESS;Database=BookStore;Trusted_Connection=True;MultipleActiveResultSets=true";
            return connection;
        }
        public int add(Models.Book objeto)
        {
            var rows = 0;
            var param = new DynamicParameters();
            var query = $@"INSERT INTO Books(Guid, Name, Price, Pages, Language) VALUES (@guid, @name,
                        @price, @pages, @language";
            param.Add("guid", objeto.Guid);
            param.Add("name", objeto.Name);
            param.Add("price", objeto.Price);
            param.Add("pages", objeto.Pages);
            param.Add("language", objeto.Language);
            using(var sql = new SqlConnection(GetConnection()))
            {
                rows = sql.Execute(query, param: param, commandType: System.Data.CommandType.Text);
            }

            return rows;
        }

        public int delete(int id)
        {
            var rows = 0;
            var param = new DynamicParameters();
            var query = $@"DELETE FROM Books WHERE Guid = @Guid";
            param.Add("Guid", id);
            using(var sql = new SqlConnection(GetConnection()))
            {
                rows = sql.Execute(query, param: param, commandType: System.Data.CommandType.Text);
            }

            return rows;
        }

        public List<Models.Book> GetAll()
        {
            var query = $@"SELECT Id, Guid, Name, Price, Pages, Language from Books";
            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Query<Models.Book>(query, commandType: System.Data.CommandType.Text).ToList();
            }
        }

        public Models.Book GetOne(int id)
        {
            var query = $@"SELECT Id, Guid, Name, Price, Pages, Language from Books where Guid = @Guid";
            var param = new DynamicParameters();
            param.Add("Guid", id);
            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Query<Models.Book>(query, param: param, commandType: System.Data.CommandType.Text).FirstOrDefault();
            }
        }

        public int update(Models.Book objeto)
        {
            var query = $@"UPDATE Books SET Name = @Name, Price = @Price, Pages = @Pages, Language = @Language where
            Guid = @Guid";
            var param = new DynamicParameters();
            param.Add("Name", objeto.Name);
            param.Add("Price", objeto.Price);
            param.Add("Pages", objeto.Pages);
            param.Add("Language", objeto.Language);
            param.Add("Guid", objeto.Guid);
            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Execute(query, param: param, commandType: System.Data.CommandType.Text);
            }
        }
    }
}
