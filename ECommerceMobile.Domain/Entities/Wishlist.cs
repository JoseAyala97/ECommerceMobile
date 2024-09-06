using ECommerceMobile.Domain.Common;

namespace ECommerceMobile.Domain.Entities
{
    public class Wishlist : BaseDomainModel
    {
        public string? UserId { get; set; }
        public virtual ICollection<WishlistProduct> WishlistProducts { get; set; }

        public Wishlist()
        {
            WishlistProducts = new HashSet<WishlistProduct>();
        }
    }
}
