using CulinaryForum.Models;
using CulinaryForum.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryForum.Controllers;

[Authorize]
public class PostController(IPostRepository postRepository, UserManager<UserEntity> userManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly IPostRepository _postRepository = postRepository;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var posts = await _postRepository.GetAllAsync();
        return View(posts);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PostEntity post)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);

            post.AuthorId = user.Id;
            post.PostedDate = DateTime.UtcNow;

            await _postRepository.AddAsync(post);

            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);

        if (post is null)
            return NotFound();

        return View(post);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PostEntity post)
    {
        if (ModelState.IsValid)
        {
            await _postRepository.UpdateAsync(post);
            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _postRepository.GetByIdAsync(id);

        if (post is null)
            return NotFound();

        return View(post);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _postRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}