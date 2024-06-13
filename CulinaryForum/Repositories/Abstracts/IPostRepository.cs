using CulinaryForum.Models;

namespace CulinaryForum.Repositories.Abstracts;

public interface IPostRepository
{
    Task<IEnumerable<PostEntity>> GetAllAsync();
    Task<PostEntity> GetByIdAsync(int id);

    Task AddAsync(PostEntity post);

    Task UpdateAsync(PostEntity post);
    Task DeleteAsync(int id);
}