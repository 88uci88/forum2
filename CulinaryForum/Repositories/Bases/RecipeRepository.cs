using CulinaryForum.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using CulinaryForum.Data;
using CulinaryForum.Models;

namespace CulinaryForum.Repositories.Bases;

public class RecipeRepository(ApplicationDbContext context) : IRecipeRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<RecipeEntity>> GetAllAsync()
    {
        return await _context.Recipes.ToListAsync();
    }

    public async Task<RecipeEntity> GetByIdAsync(int id)
    {
        return await _context.Recipes.FindAsync(id);
    }

    public async Task AddAsync(RecipeEntity recipe)
    {
        await _context.Recipes.AddAsync(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RecipeEntity recipe)
    {
        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);
        if (recipe != null)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }
    }
}