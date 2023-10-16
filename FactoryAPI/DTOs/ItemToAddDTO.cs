using System.ComponentModel.DataAnnotations;

namespace FactoryAPI.DTOs
{
    /// <summary>
    /// Just an DTO to use while adding a new record to table. There is no need for Id (autoincrements).
    /// </summary>
    public class ItemToAddDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
