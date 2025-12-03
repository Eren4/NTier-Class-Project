using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Dtos
{
    public class OrderDto : BaseDto
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
