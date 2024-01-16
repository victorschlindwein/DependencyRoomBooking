using DependencyRoomBooking.Models;
using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IBookService _bookService;
    private readonly ICustomerService _customerService;

    public BookController(
        ICustomerService customerService,
        IPaymentService paymentService,
        IBookService bookService
        )
    {
        _customerService = customerService;
        _paymentService = paymentService;
        _bookService = bookService;
    }

    [Route("v1/book")]
    [HttpPost]
    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        var customer = await _customerService.GetCustomerAsync(command.Email);
        if (customer == null)
            return NotFound();

        var room = await _bookService.CheckRoomAvailable(command.RoomId, command.Day, command.Day.AddDays(5));
        if (room)
            return BadRequest();

        var response = await _paymentService.Pay(command.Email, command.CreditCard);
        if (response is null)
            return BadRequest();
        if (response?.Status != "paid")
            return BadRequest();

        var book = await _bookService.CreateNewBook(
            command.Email,
            command.RoomId,
            command.Day
        );

        if (book is null)
            return BadRequest();

        return Ok(book);
    }
}