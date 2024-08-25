using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ECommerceAppDemo.API.Data;
using ECommerceAppDemo.API.Models;
using ECommerceAppDemo.API.Repositories;
using ECommerceAppDemo.API.Services;

namespace ECommerceAppDemo.API.Controllers
{
    public class CartController : ApiController
    {

        private readonly CartService _cartService;

        public CartController()
        {
            _cartService = new CartService(new CartRepository(new ECommerceDbContext()));
        }

        // GET api/cart/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCartById(int id)
        {
            var cart = _cartService.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        // GET api/cart
        [HttpGet]
        public IHttpActionResult GetAllCarts()
        {
            var carts = _cartService.GetAllCarts();
            return Ok(carts);
        }

        // POST api/cart
        [HttpPost]
        public IHttpActionResult AddToCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _cartService.AddToCart(cart);
            return CreatedAtRoute("DefaultApi", new { id = cart.CartId }, cart);
        }

        // PUT api/cart/{id}
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingCart = _cartService.GetCartById(id);
            if (existingCart == null)
            {
                return NotFound();
            }
            cart.CartId = id;
            _cartService.UpdateCart(cart);
            return Ok(cart);
        }

        // DELETE api/cart/{id}
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCart(int id)
        {
            var existingCart = _cartService.GetCartById(id);
            if (existingCart == null)
            {
                return NotFound();
            }
            _cartService.DeleteCart(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("clear")]
        public IHttpActionResult ClearAllCarts()
        {
            _cartService.DeleteAllCarts();
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
