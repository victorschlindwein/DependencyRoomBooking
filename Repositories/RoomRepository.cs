using System.Runtime.CompilerServices;
using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public async Task<Room?> GetRoomAsync(Guid roomId, DateTime dateStart, DateTime dateEnd)
        {
            await using var connection = new SqlConnection();

            var room = await connection.QueryFirstOrDefaultAsync<Room?>(
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
