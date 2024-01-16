using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Repositories;
using Microsoft.Data.SqlClient;
using DependencyRoomBooking.Services.Contracts;
using DependencyRoomBooking.Services;

namespace DependencyRoomBooking.Extensions
{
    public static class DependenciesExtension
    {
        public static void AddSqlConnection(
            this IServiceCollection services,
            string connectString)
        {
            services.AddScoped(x
                => new SqlConnection(connectString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IBookService, BookService>();
        }
    }
}
