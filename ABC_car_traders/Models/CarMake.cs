using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders.Models
{
    public class CarMake
    {
        public int Id { get; set; }
        public string Make { get; set; }

        // Foreign key for CarModel
        public int CarModelId { get; set; }

        // Navigation property
        public virtual CarModel CarModel { get; set; }
    }
}
