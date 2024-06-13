using CulinaryForum.Models;

namespace CulinaryForum.Repositories.Abstracts;

public interface IRecipeRepository
{
    Task<IEnumerable<RecipeEntity>> GetAllAsync();
    Task<RecipeEntity> GetByIdAsync(int id);

    Task AddAsync(RecipeEntity recipe);

    Task UpdateAsync(RecipeEntity recipe);
    Task DeleteAsync(int id);
}