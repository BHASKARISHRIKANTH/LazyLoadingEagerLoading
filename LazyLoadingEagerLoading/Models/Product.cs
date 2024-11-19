using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoadingEagerLoading.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        

        // Navigation property
        public virtual Category Category { get; set; }
        [ForeignKey("Product")]
        public int? CategoryId { get; set; }
    }
}
