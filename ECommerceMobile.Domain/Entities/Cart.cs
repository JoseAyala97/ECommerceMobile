using ECommerceMobile.Domain.Common;

namespace ECommerceMobile.Domain.Entities
{
    public class Cart : BaseDomainModel
    {
        public string? UserId { get; set; }
        public double Total { get; private set; }
        public virtual ICollection<CartItem> Items { get; set; }
        public Cart()
        {
            Items = new List<CartItem>();
            CalculateTotal();
        }
        public void CalculateTotal()
        {
            Total = Items
                .Where(item => item.CartId == this.Id)
                .Sum(item => item.Product.Price * item.Quantity);
        }
    }
}
