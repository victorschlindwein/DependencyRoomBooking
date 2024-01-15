using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Services.Contracts
{
    public interface IPaymentService
    {
        Task<PaymentResponse?> Pay(string email, CreditCard creditCard);
    }
}
