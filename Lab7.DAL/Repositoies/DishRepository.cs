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
    public class DishRepository:IRepository<Dish>
    {
        private DataContext db;

        public DishRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<Dish> GetAll()
        {
            return db.Dishes;
        }

        public Dish Get(int id)
        {
            return db.Dishes.Find(id);
        }

        public void Create(Dish dish)
        {
            db.Dishes.Add(dish);
        }

        public void Update(Dish dish)
        {
            db.Entry(dish).State = EntityState.Modified;
        }

        public IEnumerable<Dish> Find(Func<Dish, Boolean> predicate)
        {
            return db.Dishes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Dish dish = db.Dishes.Find(id);
            if (dish != null)
                db.Dishes.Remove(dish);
        }
    }
}
