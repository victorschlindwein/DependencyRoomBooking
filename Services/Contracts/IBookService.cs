namespace DependencyRoomBooking.Services.Contracts
{
    public interface IBookService
    {
        Task<bool> CheckRoomAvailable(Guid roomId, DateTime dateStart, DateTime dateEnd);

        Task<Guid?> CreateNewBook(string email, Guid roomId, DateTime day);
    }
}
