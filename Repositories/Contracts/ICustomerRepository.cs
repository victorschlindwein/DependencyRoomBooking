using DependencyRoomBooking.Models;

namespace DependencyRoomBooking.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerAsync(string email);
    }
}
