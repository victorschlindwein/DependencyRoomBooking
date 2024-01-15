using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Repositories.Contracts
{
    public interface IRoomRepository
    {
        Task<Room?> GetRoomAsync(Guid roomId, DateTime dateStart, DateTime dateEnd);
    }
}
