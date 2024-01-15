namespace DependencyRoomBooking.Models
{
    public class CreditCard
    {
        public CreditCard(string number, string holder, string expiration, string cvv)
        {
            Number = number;
            Holder = holder;
            Expiration = expiration;
            Cvv = cvv;
        }

        public string Number { get; set; }
        public string Holder { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }
    }
}
