namespace DependencyRoomBooking.Models
{
    public class Book
    {
        public Book(string email, Guid roomId, DateTime day)
        {
            Email = email;
            RoomId = roomId;
            Day = day;
        }

        public string Email { get; }
        public Guid RoomId { get; }
        public DateTime Day { get; }

        public record Get(string Email, Guid Room, DateTime Date);
    }
}
