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
    public class MenuRepository:IRepository<Menu>
    {
        private DataContext db;

        public MenuRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<Menu> GetAll()
        {
            return db.MenuItems.Include(o => o.Dish).Include(o => o.Size).Include(o => o.Orders).Include(o=>o.Dish.Ingredients);
        }

        public Menu Get(int id)
        {
            return db.MenuItems.Find(id);
        }

        public void Create(Menu menu)
        {
            db.MenuItems.Add(menu);
        }

        public void Update(Menu menu)
        {
            db.Entry(menu).State = EntityState.Modified;
        }

        public IEnumerable<Menu> Find(Func<Menu, Boolean> predicate)
        {
            return db.MenuItems.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Menu menu = db.MenuItems.Find(id);
            if (menu != null)
                db.MenuItems.Remove(menu);
        }
    }
}
