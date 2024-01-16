using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Services.Contracts;

namespace DependencyRoomBooking.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> CheckRoomAvailable(Guid roomId, DateTime dateStart, DateTime dateEnd)
        {
            var book = await _bookRepository.GetBookByRoomIdAndPeriodStartEnd(roomId, dateStart, dateEnd);

            if (book == null)
                return false;

            return true;
        }

        public async Task<Guid?> CreateNewBook(string email, Guid roomId, DateTime day)
        {
            var book = new Book(email, roomId, day);

            var createBook = await _bookRepository.CreateBookAsync(book);

            if (!createBook.HasValue)
                return null;

            var newBook = await _bookRepository.GetBookByRoomIdAndPeriodStartEnd(roomId, day.Date, day.Date.AddDays(1).AddTicks(-1));
            return newBook?.RoomId;

        }
    }
}
