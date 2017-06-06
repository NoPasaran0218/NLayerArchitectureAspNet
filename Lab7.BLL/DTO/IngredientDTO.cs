using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.BLL.DTO
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DishDTO> Dishes { get; set; }

        public IngredientDTO()
        {
            Dishes = new List<DishDTO>();
        }
    }
}
