using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SqlConnection _connection;

        public RoomRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<Room?> GetRoomAsync(Guid roomId, DateTime dateStart, DateTime dateEnd)
        {
            var room = await _connection.QueryFirstOrDefaultAsync<Room?>(
                "SELECT * FROM [Book] WHERE [Room]=@room AND [Date] BETWEEN @dateStart AND @dateEnd",
                new
                {
                    Room = roomId,
                    DateStart = dateStart,
                    DateEnd = dateEnd.AddDays(1).AddTicks(-1),
                });

            return room;
        }
    }
}
