using CulinaryForum.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using CulinaryForum.Data;
using CulinaryForum.Models;

namespace CulinaryForum.Repositories.Bases;

public class PostRepository(ApplicationDbContext context) : IPostRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<PostEntity>> GetAllAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task<PostEntity> GetByIdAsync(int id)
    {
        return await _context.Posts.FindAsync(id);
    }

    public async Task AddAsync(PostEntity post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PostEntity post)
    {
        await _context.Posts
            .Where(p => p.Id == post.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Title, post.Title)
                .SetProperty(p => p.Content, post.Content));
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Posts
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();
    }
}