namespace Project.WebApi.Models.ResponseModels.Products
{
    public class ProductResponseModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}
