using CulinaryForum.Data;
using CulinaryForum.Models;
using CulinaryForum.Repositories.Abstracts;
using CulinaryForum.Repositories.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CulinaryForum.Controllers;

[Authorize]
public class RecipeController(IRecipeRepository recipeRepository, UserManager<UserEntity> userManager) : Controller
{
    private readonly IRecipeRepository _recipeRepository = recipeRepository;
    private readonly UserManager<UserEntity> _userManager = userManager;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var recipes = await _recipeRepository.GetAllAsync();
        return View(recipes);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(RecipeEntity recipe)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            recipe.AuthorId = user.Id;
            await _recipeRepository.AddAsync(recipe);
            return RedirectToAction(nameof(Index));
        }
        return View(recipe);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return View(recipe);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(RecipeEntity recipe)
    {
        if (ModelState.IsValid)
        {
            await _recipeRepository.UpdateAsync(recipe);
            return RedirectToAction(nameof(Index));
        }
        return View(recipe);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return View(recipe);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _recipeRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
}