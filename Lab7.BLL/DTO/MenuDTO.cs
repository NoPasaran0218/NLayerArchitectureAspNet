using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.BLL.DTO
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public DishDTO Dish { get; set; }
        public SizeDTO Size { get; set; }
        public int SizeId { get; set; }
        public int DishId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public ICollection<OrderDTO> Orders { get; set; }

        public MenuDTO()
        {
            Orders = new List<OrderDTO>();
        }
    }
}
