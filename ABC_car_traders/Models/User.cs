using ABC_car_traders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders.Models
{
    public class User : CommonProperty
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Generate a new Guid for each new User
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true; // Default value is true      
    }
}
