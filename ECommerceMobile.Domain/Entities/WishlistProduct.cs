namespace ECommerceMobile.Domain.Entities
{
    public class WishlistProduct
    {
        public int WishlistId { get; set; }
        public virtual Wishlist Wishlist { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
