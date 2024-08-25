using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceAppDemo.API.Data;
using ECommerceAppDemo.API.Models;

namespace ECommerceAppDemo.API.Repositories
{
    public class CartRepository
    {

        private readonly ECommerceDbContext _context;

        public CartRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public Cart GetCartById(int cartId)
        {
            return _context.Carts.FirstOrDefault(c => c.CartId == cartId);
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _context.Carts.ToList();
        }

        public void AddToCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            // Retrieve the existing entity from the database
            var existingCart = _context.Carts.Find(cart.CartId);

            if (existingCart != null)
            {
                // Update only the fields you want to change
                existingCart.Quantity = cart.Quantity;
                existingCart.Price = cart.Price;
                // Update other fields as necessary

                // Save changes to the database
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Cart item not found.");
            }
        }

        public void DeleteCart(int cartId)
        {
            var cart = GetCartById(cartId);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }
        }

        public void DeleteAllCarts()
        {
            // Fetch all cart entries
            var allCarts = _context.Carts.ToList();

            // Remove all cart entries
            if (allCarts.Any())
            {
                _context.Carts.RemoveRange(allCarts);
                _context.SaveChanges();
            }
        }

    }
}
