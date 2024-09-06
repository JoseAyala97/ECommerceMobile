using ECommerceMobile.Domain.Common;

namespace ECommerceMobile.Domain.Entities
{
    public class CartItem : BaseDomainModel
    {
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } 
        public int Quantity { get; set; }
    }
}
