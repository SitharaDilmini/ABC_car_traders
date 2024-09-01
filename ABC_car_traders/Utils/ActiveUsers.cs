using ABC_Car_Traders.Data;
using ABC_Car_Traders.Models;
using System;
using System.Linq;

namespace ABC_car_traders.Utils
{
    public class ActiveUsers
    {
        private readonly AppDbContext _context;

        public ActiveUsers(AppDbContext context)
        {
            _context = context;
        }

        public User GetUser(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.Name == userName);
        }

        public void UpdateUserActivityStatus()
        {
            var users = _context.Users.ToList();
            var orders = _context.Orders.ToList();
            var cartItems = _context.CartItems.ToList();

            foreach (var user in users)
            {
                var lastOrder = orders.Where(o => o.UserId == user.Id).OrderByDescending(o => o.CreatedDate).FirstOrDefault();
                var lastCart = cartItems.Where(c => c.UserId == user.Id).OrderByDescending(c => c.CreatedDate).FirstOrDefault();

                if (lastOrder != null && lastOrder.CreatedDate.AddMonths(6) < DateTime.Now)
                {
                    user.IsActive = false;
                }
                else if (lastCart != null && lastCart.CreatedDate.AddMonths(6) < DateTime.Now)
                {
                    user.IsActive = false;
                }
                else if (lastOrder == null && lastCart == null)
                {
                    user.IsActive = false;
                }
                else
                {
                    user.IsActive = true;
                }
            }
            _context.SaveChanges();
        }
    }
}
