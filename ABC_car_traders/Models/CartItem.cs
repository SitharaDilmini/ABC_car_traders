using ABC_car_traders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders.Models
{
    public class CartItem : CommonProperty
    {
        public Guid Id { get; set; }
        public Guid? CarId { get; set; }
        public Guid? SparePartId { get; set; }
        public Guid UserId { get; set; }

        public virtual Car Car { get; set; }
        public virtual CarSparePart SparePart { get; set; }
        public virtual User User { get; set; }



    }
}
