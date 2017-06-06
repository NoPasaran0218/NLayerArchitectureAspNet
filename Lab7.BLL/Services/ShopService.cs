using AutoMapper;
using Lab7.BLL.DTO;
using Lab7.BLL.Infrastructure;
using Lab7.BLL.Interfaces;
using Lab7.DAL.Entities;
using Lab7.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.BLL.Services
{
    public class ShopService : IShopService
    {
        IUnitOfWork Database { get; set; }

        public ShopService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeOrder(int [] menuIds, int price)
        {
            Order order = new Order()
            {
                Complite = false,
                Date = DateTime.Now
            };

            for( int i =0;i<menuIds.Count();i++)
            {
                var obj = Database.MenuItems.Get(menuIds[i]);
                if (obj != null)
                {
                    order.MenuItems.Add(obj);
                }
            }
            order.Price = price;
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<MenuDTO> GetMenuItems()
        {
            Mapper.Initialize(o=> o.CreateMap<Menu, MenuDTO>().PreserveReferences());
            IEnumerable<Menu> menuList = Database.MenuItems.GetAll();
            List<MenuDTO> temp = new List<MenuDTO>();
            foreach (var item in menuList)
            {
                temp.Add(MyMapper.MenuToMenuDTO(item));
            }
            return temp;
        }

        public IEnumerable<OrderDTO> GetAllOrder()
        {
            IEnumerable<Order> orders = Database.Orders.GetAll();
            List<OrderDTO> orderResult = new List<OrderDTO>();
            foreach(var order in orders)
            {
                orderResult.Add(MyMapper.OrderToOrderDTO(order));
            }
            return orderResult;
        }

        public void CompliteOrder(int id)
        {
            var order = Database.Orders.Get(id);
            if (order != null)
            {
                order.Complite = true;
                Database.Save();
            }
            else
            {
                throw new NullReferenceException("Object not found");
            }
        }

        public void AddMenuItem(MenuDTO item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
