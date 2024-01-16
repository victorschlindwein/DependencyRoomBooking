using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task<Book?> CheckRoomAvailable(Guid roomId, DateTime dateStart, DateTime dateEnd);
        Task<bool> CreateBookAsync(Book book);
    }
}
