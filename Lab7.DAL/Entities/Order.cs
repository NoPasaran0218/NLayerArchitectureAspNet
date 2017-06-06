using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Complite { get; set; }
        public int Price { get; set; }
        public ICollection<Menu> MenuItems { get; set; }

        public Order()
        {
            MenuItems = new List<Menu>();
        }
    }
}
