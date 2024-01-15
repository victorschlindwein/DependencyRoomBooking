using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<Book?> CreateBookAsync(string email, Guid roomId, DateTime dateStart, DateTime dateEnd);
    }
}
