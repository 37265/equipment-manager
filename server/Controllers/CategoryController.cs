using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using server.Data;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(EquipmentBookingContext context) 
    : ControllerBase // Remember to inherit!!!
{

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Get(int id)
    {
        var result = await context.Categories.FindAsync(id);

        if (result == null)
        {
            return NotFound();
        }

        return result;
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Add(Category category)
    {
        var categoryItem = new Category()
        {
            Name = category.Name,
            Description = category.Description
        };

        context.Categories.Add(categoryItem);

        await context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Get),
            new
            {
                id = categoryItem.ID
            },
            categoryItem
        );
    }
}