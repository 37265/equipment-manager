using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using server.Data;
using server.Models;
using server.DTOs;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(ICategoryService service) : ControllerBase // Remember to inherit!!!
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Get(int id)
    {
        var result = await service.Get(id);

        if (result == null)
        {
            return NotFound();
        }

        return result;
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Add(CreateCategoryDto dto)
    {
        var categoryItem = await service.Add(dto);

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