using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Complite { get; set; }
        public int Price { get; set; }
        public ICollection<MenuDTO> MenuItems { get; set; }

        public OrderDTO()
        {
            MenuItems = new List<MenuDTO>();
        }
    }
}
