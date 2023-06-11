namespace Tech_Market_WebMVC7UI.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int computerId, int qty);
        Task<int> RemoveItem(int computerId);

        Task<ShoppingCart> GetUserCart();

        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);

    }
}
