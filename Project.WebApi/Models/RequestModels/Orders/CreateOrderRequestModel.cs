namespace Project.WebApi.Models.RequestModels.Orders
{
    public class CreateOrderRequestModel
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
