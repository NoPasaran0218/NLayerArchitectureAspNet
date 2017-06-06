using Lab7.DAL.EF;
using Lab7.DAL.Entities;
using Lab7.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.DAL.Repositoies
{
    public class OrderRepository:IRepository<Order>
    {
        private DataContext db;

        public OrderRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.MenuItems.Select(a=>a.Dish)).Include(o1=>o1.MenuItems.Select(o2=>o2.Size));
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
