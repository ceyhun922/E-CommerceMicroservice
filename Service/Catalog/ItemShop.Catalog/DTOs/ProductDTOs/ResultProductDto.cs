namespace ItemShop.Catalog.DTOs.ProductDTOs
{
    public class ResultProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public bool ProductStatus { get; set; }
        public string CategoryId { get; set; }
    }
}