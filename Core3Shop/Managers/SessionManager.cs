using Core3Shop.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.Managers
{
    public class SessionManager
    {
        private HttpContext _context;
        private const string SessionCartKey = "ShoppingCart";
        List<int> servicesList = new List<int>();

        public SessionManager(HttpContext context)
        {
            _context = context;
        }
        private void LoadCart()
        {
            if (!string.IsNullOrEmpty(_context.Session.GetString(SessionCartKey)))
            {
                servicesList = _context.Session.GetObject<List<int>>(SessionCartKey);
            }
        }
        public void AddToCart(int id)
        {
            LoadCart();
            if (!servicesList.Contains(id))
            {
                servicesList.Add(id);
            }
            _context.Session.SetObject(SessionCartKey, servicesList);
        }
        public void DeleteFromCart(int id)
        {
            LoadCart();
            if (servicesList.Contains(id))
            {
                servicesList.Remove(id);
                _context.Session.SetObject(SessionCartKey, servicesList);
            }
        }
        public List<int> GetCart()
        {
            LoadCart();
            return servicesList;
        }
    }
}
