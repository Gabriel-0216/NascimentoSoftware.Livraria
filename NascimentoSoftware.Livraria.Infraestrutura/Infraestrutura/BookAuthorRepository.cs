using Dapper;
using NascimentoSoftware.Livraria.Infraestrutura.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NascimentoSoftware.Livraria.Infraestrutura.Infraestrutura
{
    public class BookAuthorRepository : IRepository<Models.BookAuthor>
    {
        public string GetConnection()
        {
            var connection = $@"Server=DESKTOP-2L16HEL\SQLEXPRESS;Database=BookStore;Trusted_Connection=True;MultipleActiveResultSets=true";
            return connection;
        }
        public int add(BookAuthor objeto)
        {
            var param = new DynamicParameters();
            param.Add("AuthorGuid", objeto.AuthorGuid);
            param.Add("RegisterDate", objeto.RegisterDate);
            param.Add("BookGuid", objeto.BookGuid);

            var query = $@"INSERT INTO BookAuthor(BookAuthorGuid, AuthorGuid, BookGuid, RegisterDate) VALUES (@BookAuthorGuid, @AuthorGuid, @BookGuid, @RegisterDate)";

            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Execute(query, param: param, commandType: System.Data.CommandType.Text);
            }
        }

        public int delete(int id)
        {
            var param = new DynamicParameters();
            param.Add("bookAuthorGuid", id);

            var query = $@"Delete from BookAuthor where BookAuthorGuid = @id";

            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Execute(query, param: param, commandType: System.Data.CommandType.Text);
            }
        }

        public List<BookAuthor> GetAll()
        {
            var query = $@"Select Id, BookAuthorGuid, AuthorGuid, BookGuid, RegisterDate from BookAuthor";
            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Query<BookAuthor>(query, commandType: System.Data.CommandType.Text).ToList();
            }
        }

        public BookAuthor GetOne(int id)
        {
            var param = new DynamicParameters();
            param.Add("BookAuthorGuid", id);
            var query = $@"Select Id, BookAuthorGuid, AuthorGuid, BookGuid, RegisterDate from BookAuthor where BookAuthorGuid = @id";
            using (var sql = new SqlConnection(GetConnection()))
            {
                return sql.Query<BookAuthor>(query, param: param, commandType: System.Data.CommandType.Text).FirstOrDefault();
            }
        }

        public int update(BookAuthor objeto)
        {
            var param = new DynamicParameters();
            param.Add("AuthorGuid", objeto.AuthorGuid);
            param.Add("BookGuid", objeto.BookGuid);
            param.Add("BookAuthorGuid", objeto.BookAuthorGuid);

            var query = $@"UPDATE BookAuthor SET AuthorGuid = @authorGuid, BookGuid = @BookGuid where BookAuthorGuid = @id";

            using(var sql = new SqlConnection(GetConnection()))
            {
                return sql.Execute(query, param: param, commandType: System.Data.CommandType.Text);
            }
        }
    }
}
