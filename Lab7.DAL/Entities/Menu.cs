using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.DAL.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public Size Size { get; set; }
        public int SizeId { get; set; }
        public int DishId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Menu()
        {
            Orders = new List<Order>();
        }
    }
}
