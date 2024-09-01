using ABC_car_traders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders.Models
{
    public class Car : CommonProperty
    {
        public Guid Id { get; set; }

        // Foreign key for CarMake
        public int CarMakeId { get; set; }

        public int Year { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string EngineCapacity { get; set; }
        public string BodyType { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string AdditionalFeatures { get; set; }
       

        // Navigation property
        public virtual CarMake CarMake { get; set; }
    }
}
