using Dapper;
using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyRoomBooking.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<Customer?> GetCustomerAsync(string email)
        {
            await using var connection = new SqlConnection();
            return await connection
                .QueryFirstOrDefaultAsync<Customer?>("SELECT * FROM [Customer] WHERE [Email]=@email",
                    new { email });
        }
    }
}
