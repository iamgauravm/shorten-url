using Microsoft.EntityFrameworkCore;
using ShortenUrl.Core.Entities;

namespace ShortenUrl.Core;

public interface IShortenDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}

