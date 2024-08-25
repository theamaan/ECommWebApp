using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceAppDemo.API.Models;
using ECommerceAppDemo.API.Repositories;

namespace ECommerceAppDemo.API.Services
{
    public class CartService
    {

        private readonly CartRepository _cartRepository;

        public CartService(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart GetCartById(int cartId)
        {
            return _cartRepository.GetCartById(cartId);
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _cartRepository.GetAllCarts();
        }

        public void AddToCart(Cart cart)
        {
            _cartRepository.AddToCart(cart);
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.UpdateCart(cart);
        }

        public void DeleteCart(int cartId)
        {
            _cartRepository.DeleteCart(cartId);
        }

        public void DeleteAllCarts()
        {
            _cartRepository.DeleteAllCarts();
        }

    }
}