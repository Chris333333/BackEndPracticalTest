using FactoryAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FactoryAPI.Entities
{
    /// <summary>
    /// Entity Framework Core DbContext for Items table
    /// </summary>
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

    }
}