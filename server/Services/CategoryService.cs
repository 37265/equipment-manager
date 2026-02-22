using server.Data;
using server.Models;
using Microsoft.AspNetCore.Mvc;
using server.DTOs;

namespace server.Services;

public class CategoryService(EquipmentBookingContext context) : ICategoryService
{
    // The question mark handles the case where no record is found; makes the return value nullable
    public async Task<Category?> Get(int id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task<Category> Add(CreateCategoryDto dto)
    {
        var categoryItem = new Category()
        {
            Name = dto.Name,
            Description = dto.Description
        };
        
        await context.Categories.AddAsync(categoryItem);
        await context.SaveChangesAsync();

        return categoryItem;
    }
}