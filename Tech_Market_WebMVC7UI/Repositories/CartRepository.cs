using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tech_Market_WebMVC7UI.Models;

namespace Tech_Market_WebMVC7UI.Repositories
{
    public class CartRepository: ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor,
            UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddItem(int computerId, int qty)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                string userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return false;
                }
                var cart = await GetCart(userId);
                if (cart is null)
                {
                    cart = new ShoppingCart
                    {
                        UserId = userId
                    };
                    _db.ShoppingCarts.Add(cart);
                }
                _db.SaveChanges();
                // Kart detayları eklenecek
                var cartItem = _db.CartDetails.FirstOrDefault(a => a.ShoppingCart_Id == cart.Id && a.ComputerId == computerId);
                if (cartItem != null)
                {
                    cartItem.Quantitiy += qty;
                }
                else
                {
                    cartItem = new CartDetail
                    {
                        ComputerId = computerId,
                        ShoppingCart_Id = cart.Id,
                        Quantitiy = qty
                    };
                    _db.CartDetails.Add(cartItem);
                }
                _db.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> RemoveItem(int computerId)
        {
            //using var transaction = _db.Database.BeginTransaction();
            try
            {
                string userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return false;
                }
                var cart = await GetCart(userId);
                if (cart is null)
                {
                    return false;
                }
                // Kart detayları eklenecek
                var cartItem = _db.CartDetails.FirstOrDefault(a => a.ShoppingCart_Id == cart.Id && a.ComputerId == computerId);
                if (cartItem == null)
                {
                    return false;
                }
                else if (cartItem.Quantitiy == 1)
                {
                    _db.CartDetails.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantitiy = cartItem.Quantitiy - 1;
                }
                _db.SaveChanges();
                //transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<IEnumerable<ShoppingCart>> GetUserCart()
        {
            var userId = GetUserId();
            if (userId == null)
            {
                throw new Exception("Invalid UserId");
            }
            var shoppingCart = await _db.ShoppingCarts
                .Include(a => a.CartDetails)
                .ThenInclude(a => a.Computer)
                .ThenInclude(a => a.Genre) 
                .Where(a => a.UserId == userId).ToListAsync();

            return shoppingCart;
        }




        private async Task<ShoppingCart> GetCart(string userId)
        {
            var cart =await  _db.ShoppingCarts.FirstOrDefaultAsync(x => x.UserId == userId);
            return cart;
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }
    }
}
