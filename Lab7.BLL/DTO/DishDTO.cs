using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.BLL.DTO
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<IngredientDTO> Ingredients { get; set; }
        public ICollection<MenuDTO> Menus { get; set; }
        public DishDTO()
        {
            Ingredients = new List<IngredientDTO>();
        }
    }
}
