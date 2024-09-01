using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders.Models
{
    public class CarSparePart
    {

        public Guid Id { get; set; }
        public string PartName { get; set; }

        // Foreign key for CarMake
        public int CarMakeId { get; set; }

        public string Description { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public string WarrantyPeriod { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeletedAt { get; set; } 

        // Navigation property
        public virtual CarMake CarMake { get; set; }
    }
}
