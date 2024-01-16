﻿using DependencyRoomBooking.Models;
using DependencyRoomBooking.Services.Contracts;
using RestSharp;

namespace DependencyRoomBooking.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<PaymentResponse?> Pay(string email, CreditCard creditCard)
        {
            var client = new RestClient("https://payments.com");
            var request = new RestRequest()
                .AddQueryParameter("api_key", "c20c8acb-bd76-4597-ac89-10fd955ac60d")
                .AddJsonBody(new
                {
                    User = email,
                    CreditCard = creditCard
                });
            var paymentResponse = await client.PostAsync<PaymentResponse>(request);

            return paymentResponse;
        }
    }
}
