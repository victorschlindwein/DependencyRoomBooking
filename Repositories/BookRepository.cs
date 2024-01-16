using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SqlConnection _connection;

        public BookRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<Book?> CreateBookAsync(string email, Guid roomId, DateTime dateStart, DateTime dateEnd)
        {
            var book = new Book(email, roomId, dateStart);

            await _connection.ExecuteAsync("INSERT INTO [Book] VALUES(@date, @email, @room)", new
            {
                dateStart,
                email,
                roomId
            });

            return book;
        }
    }
}
