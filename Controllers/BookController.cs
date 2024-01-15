using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IPaymentService _paymentService;

    public BookController(
        ICustomerRepository customerRepository,
        IRoomRepository roomRepository,
        IBookRepository bookRepository, 
        IPaymentService paymentService
        )
    {
        _customerRepository = customerRepository;
        _roomRepository = roomRepository;
        _bookRepository = bookRepository;
        _paymentService = paymentService;
    }

    [Route("v1/book")]
    [HttpPost]
    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        var customer = await _customerRepository.GetCustomerAsync(command.Email);
        if (customer == null)
            return NotFound();

        var room = await _roomRepository.GetRoomAsync(command.RoomId, command.Day, command.Day.AddDays(5));
        if (room is not null)
            return BadRequest();

        var response = await _paymentService.Pay(command.Email, command.CreditCard);
        if (response is null)
            return BadRequest();
        if (response?.Status != "paid")
            return BadRequest();

        var book = await _bookRepository.CreateBookAsync(
            command.Email,
            command.RoomId,
            command.Day,
            command.Day.AddDays(5)
        );

        return Ok(book?.RoomId);
    }
}