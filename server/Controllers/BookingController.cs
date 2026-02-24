using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.DTOs.Bookings;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController(EquipmentBookingContext context) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> Get(int id)
    {
        var result = await context.Bookings.FindAsync(id);

        if (result == null)
        {
            return NotFound();
        }

        return result;
    }
    [HttpPost]
    public async Task<ActionResult<Booking>> Create(CreateBookingDto dto)
    {
        // FluentValidation runs AFTER model binding occurs
        var bookingItem = new Booking()
        {
            ScheduledStart  = dto.ScheduledStart!.Value,
            ScheduledEnd    = dto.ScheduledEnd!.Value,
            UserID          = dto.UserID!.Value,
            ProductID       = dto.ProductID!.Value
        };

        await context.Bookings.AddAsync(bookingItem);
        await context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Get),
            new
            {
                id = bookingItem.ID
            },
            bookingItem
        );
    }
}