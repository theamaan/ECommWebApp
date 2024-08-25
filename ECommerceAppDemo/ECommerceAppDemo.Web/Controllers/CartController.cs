using ECommerceAppDemo.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ECommerceAppDemo.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            // Call the API to get the cart data
            string apiUrl = "https://localhost:44368/api/cart"; // Replace with your API URL
            string jsonData = new WebClient().DownloadString(apiUrl);

            // Deserialize the JSON data into a list of Cart objects
            List<Cart> cartData = JsonConvert.DeserializeObject<List<Cart>>(jsonData);

            // Pass the cart data to the View
            return View(cartData);
        }
    }
    
}