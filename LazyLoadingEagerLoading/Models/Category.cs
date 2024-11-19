namespace LazyLoadingEagerLoading.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for lazy loading
        public virtual List<Product> Products { get; set; }=new List<Product> { };
    }
}
