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
    public class IngredientRepository:IRepository<Ingredient>
    {
        private DataContext db;

        public IngredientRepository(DataContext context)
        {
            db = context;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return db.Ingredients;
        }

        public Ingredient Get(int id)
        {
            return db.Ingredients.Find(id);
        }

        public void Create(Ingredient ing)
        {
            db.Ingredients.Add(ing);
        }

        public void Update(Ingredient ing)
        {
            db.Entry(ing).State = EntityState.Modified;
        }

        public IEnumerable<Ingredient> Find(Func<Ingredient, Boolean> predicate)
        {
            return db.Ingredients.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Ingredient ing = db.Ingredients.Find(id);
            if (ing != null)
                db.Ingredients.Remove(ing);
        }
    }
}
