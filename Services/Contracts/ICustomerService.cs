using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Services.Contracts
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerAsync(string email);
    }
}
