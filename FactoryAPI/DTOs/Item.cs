using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FactoryAPI.DTOs
{
    /// <summary>
    /// Main Entity on witch I'm building my table in DbContext via Entity Framework Core
    /// </summary>
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(180)]
        public string? Description { get; set; }
        [Required]
        [Range(0.10, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
    }
}
