using Lab7.DAL.EF;
using Lab7.DAL.Entities;
using Lab7.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.DAL.Repositoies
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private DataContext db;
        private SizeRepository sizeRepository;
        private DishRepository dishRepository;
        private MenuRepository menuRepository;
        private IngredientRepository ingredientRepository;
        private OrderRepository orderRepository;

        public EFUnitOfWork(string connectionString)
        {
            this.db = new DataContext(connectionString);
        }

        public IRepository<Size> Sizes
        {
            get
            {
                if (sizeRepository == null)
                    sizeRepository = new SizeRepository(db);
                return sizeRepository;
            }
        }

        public IRepository<Dish> Dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return dishRepository;
            }
        }

        public IRepository<Ingredient> Ingredients
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepository(db);
                return ingredientRepository;
            }
        }

        public IRepository<Menu> MenuItems
        {
            get
            {
                if (menuRepository == null)
                    menuRepository = new MenuRepository(db);
                return menuRepository;
            }
        }

        public IRepository<Order> Orders 
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
