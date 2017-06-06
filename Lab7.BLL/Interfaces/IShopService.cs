using Lab7.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.BLL.Interfaces
{
    public interface IShopService
    {
        void MakeOrder(int [] menuIds, int price);
        IEnumerable<OrderDTO> GetAllOrder();
        IEnumerable<MenuDTO> GetMenuItems();
        void AddMenuItem(MenuDTO item);
        void CompliteOrder(int id);
        void Dispose();
    }
}
