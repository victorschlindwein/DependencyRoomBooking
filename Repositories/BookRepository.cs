using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Repositories
{
    public class BookRepository : IBookRepository
    {
        public async Task<Book?> CreateBookAsync(string email, Guid roomId, DateTime dateStart, DateTime dateEnd)
        {
            var book = new Book(email, roomId, dateStart);

            await using var connection = new SqlConnection();

            await connection.ExecuteAsync("INSERT INTO [Book] VALUES(@date, @email, @room)", new
            {
                dateStart,
                email,
                roomId
            });

            return book;
        }
    }
}
