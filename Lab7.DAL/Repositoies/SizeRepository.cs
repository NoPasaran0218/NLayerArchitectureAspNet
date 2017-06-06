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
    public class SizeRepository:IRepository<Size>
    {
        private DataContext db;

        public SizeRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<Size> GetAll()
        {
            return db.Sizes;
        }

        public Size Get(int id)
        {
            return db.Sizes.Find(id);
        }

        public void Create(Size size)
        {
            db.Sizes.Add(size);
        }

        public void Update(Size size)
        {
            db.Entry(size).State = EntityState.Modified;
        }

        public IEnumerable<Size> Find(Func<Size, Boolean> predicate)
        {
            return db.Sizes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Size book = db.Sizes.Find(id);
            if (book != null)
                db.Sizes.Remove(book);
        }
    }
}
