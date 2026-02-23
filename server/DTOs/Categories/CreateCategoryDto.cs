namespace server.DTOs.Categories;

public record CreateCategoryDto(
    string Name, 
    string? Description
);