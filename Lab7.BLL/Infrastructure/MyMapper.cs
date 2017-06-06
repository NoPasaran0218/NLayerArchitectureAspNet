using Lab7.BLL.DTO;
using Lab7.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.BLL.Infrastructure
{
    public class MyMapper
    {
        public static MenuDTO MenuToMenuDTO(Menu item)
        {
            MenuDTO result = new MenuDTO();
            result.Description = item.Description;
            result.DishId = item.DishId;
            result.Id = item.Id;
            result.Price = item.Price;
            result.Size = SizeToSizeDTO(item.Size);
            result.SizeId = item.SizeId;
            result.Dish = DishToDishDTO(item.Dish);
            /*foreach(var order in item.Orders)
            {
                result.Orders.Add(OrderToOrderDTO(order));
            }*/
            return result;
        }

        public static DishDTO DishToDishDTO(Dish item)
        {
            DishDTO result = new DishDTO();
            result.Id = item.Id;
            result.Name = item.Name;
            
            /*foreach(var menu in item.Menus)
            {
                result.Menus.Add(MenuToMenuDTO(menu));
            }*/

            foreach(var ingredient in item.Ingredients)
            {
                result.Ingredients.Add(IngredientToIngredientDTO(ingredient));
            }

            return result;
        }

        public static IngredientDTO IngredientToIngredientDTO(Ingredient item)
        {
            IngredientDTO result = new IngredientDTO();
            result.Id = item.Id;
            result.Name = item.Name;

            /*foreach(var dish in item.Dishes)
            {
                result.Dishes.Add(DishToDishDTO(dish));
            }*/
            return result;
        }

        public static SizeDTO SizeToSizeDTO(Size item)
        {
            SizeDTO result = new SizeDTO();
            result.Id = item.Id;
            result.Heft = item.Heft;
            result.Name = item.Name;
            /*foreach(var menu in item.Menus)
            {
                result.Menus.Add(MenuToMenuDTO(menu));
            }*/
            return result;
        }

        public static OrderDTO OrderToOrderDTO(Order item)
        {
            OrderDTO result = new OrderDTO();
            result.Id = item.Id;
            result.Date = item.Date;
            result.Complite = item.Complite;
            result.Price = item.Price;
            foreach (var menu in item.MenuItems)
                result.MenuItems.Add(MenuToMenuDTO(menu));
            return result;
        }
    }
}
