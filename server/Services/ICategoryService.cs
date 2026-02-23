using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Models;

namespace server.Services;

public interface ICategoryService
{
    public Task<List<Category>> List();
    public Task<Category?> Get(int id);
    public Task<Category> Create(CreateCategoryDto dto);
}