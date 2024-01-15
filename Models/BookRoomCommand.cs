namespace DependencyRoomBooking.Models
{
    public class BookRoomCommand
    {
        public BookRoomCommand(string email, Guid roomId, DateTime day, CreditCard creditCard)
        {
            Email = email;
            RoomId = roomId;
            Day = day;
            CreditCard = creditCard;
        }

        public string Email { get; set; }
        public Guid RoomId { get; set; }
        public DateTime Day { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
