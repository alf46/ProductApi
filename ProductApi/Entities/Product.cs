namespace ProductApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public System.DateTime CreateDate { get; set; }

        // Navigations Properties.
        public virtual Category Category { get; set; }
    }
}