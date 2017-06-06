using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.DAL.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public Dish()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
