using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Models;

namespace server.Services;

public interface ICategoryService
{
    public Task<Category?> Get(int id);
    public Task<Category> Add(CreateCategoryDto dto);
}