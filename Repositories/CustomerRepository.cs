using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlConnection _connection;

        public CustomerRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<Customer?> GetCustomerAsync(string email)
        {
            var customer = await _connection
                .QueryFirstOrDefaultAsync<Customer?>("SELECT * FROM [Customer] WHERE [Email]=@email",
                    new { email });
            return customer;
        }
    }
}
