namespace DependencyRoomBooking.Models
{
    public class PaymentResponse
    {
        public int Code { get; set; }
        public string Status { get; set; } = string.Empty;
        public record Get(int Code, string Status);
    }
}
