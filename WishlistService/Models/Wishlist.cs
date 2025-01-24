namespace WishlistService.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<WishlistItem> Items { get; set; } = []; // Wishlist can have multiple items
    }

    public class WishlistItem
    {
        public int Id { get; set; }
        public int WishlistId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Link { get; set; }
    }
}
