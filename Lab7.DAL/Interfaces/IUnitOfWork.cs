using Lab7.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Dish> Dishes { get; }
        IRepository<Ingredient> Ingredients { get; }
        IRepository<Menu> MenuItems { get; }
        IRepository<Size> Sizes { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
