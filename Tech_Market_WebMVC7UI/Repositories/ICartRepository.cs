namespace Tech_Market_WebMVC7UI.Repositories
{
    public interface ICartRepository
    {
        Task<bool> AddItem(int computerId, int qty);
        Task<bool> RemoveItem(int computerId);

        Task<IEnumerable<ShoppingCart>> GetUserCart();
    }
}
