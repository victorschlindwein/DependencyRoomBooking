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

        public async Task<Book?> CheckRoomAvailable(Guid roomId, DateTime dateStart, DateTime dateEnd)
        {
            var book = await _connection.QueryFirstOrDefaultAsync<Book?>(
                "SELECT * FROM [Book] WHERE [Room]=@room AND [Date] BETWEEN @dateStart AND @dateEnd",
                new
                {
                    Room = roomId,
                    DateStart = dateStart,
                    DateEnd = dateEnd,
                });

            return book ?? book;
        }

        public async Task<bool> CreateBookAsync(Book book)
        {
            var result = await _connection.ExecuteAsync("INSERT INTO [Book] VALUES(@date, @email, @room)", new
            {
                book.Day,
                book.Email,
                book.RoomId
            });

            if (result > 0)
                return false;

            return true;
        }
    }
}
