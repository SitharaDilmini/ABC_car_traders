using ABC_Car_Traders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_car_traders.Models
{
    public class Order : CommonProperty
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? CarId { get; set; }
        public Guid? SparePartId { get; set; }
        public int? Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string Option { get; set; }
        public int? WillBeDeliveredWithin { get; set; }
        public string Status { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
        public virtual CarSparePart CarSparePart { get; set; }

    }
}
