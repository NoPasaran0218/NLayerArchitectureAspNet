using Lab7.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.DAL.EF
{
    public class DataContext:DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Menu> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataContext(string connectionString)
            :base(connectionString)
        {

        }
        static DataContext()
        {
            Database.SetInitializer<DataContext>(new DbInitializer());
        }
    }

    public class DbInitializer:DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext db)
        {
            Ingredient i1 = new Ingredient() { Name = "Mushrooms" };
            Ingredient i2 = new Ingredient() { Name = "Tomato" };
            Ingredient i3 = new Ingredient() { Name = "Onion" };
            Ingredient i4 = new Ingredient() { Name = "Chicken meat" };
            Ingredient i5 = new Ingredient() { Name = "Sausage" };
            Ingredient i6 = new Ingredient() { Name = "Cheese" };
            Ingredient i7 = new Ingredient() { Name = "Olives" };
            Ingredient i8 = new Ingredient() { Name = "Chili sauce" };
            Ingredient i9 = new Ingredient() { Name = "Corn" };
            Ingredient i10 = new Ingredient() { Name = "Garlic sause" };

            Menu m1 = new Menu() { Price = 75 };
            Menu m2 = new Menu() { Price = 120 };
            Menu m3 = new Menu() { Price = 160 };
            Menu m4 = new Menu() { Price = 66 };
            Menu m5 = new Menu() { Price = 102 };
            Menu m6 = new Menu() { Price = 138 };
            Menu m7 = new Menu() { Price = 81 };
            Menu m8 = new Menu() { Price = 134 };
            Menu m9 = new Menu() { Price = 180 };


            Dish d1 = new Dish() { Name = "Paperoni" };
            Dish d2 = new Dish() { Name = "Kaltsone" };
            Dish d3 = new Dish() { Name = "Margarita" };

            Size s1 = new Size() { Name = "Small", Heft = 300 };
            Size s2 = new Size() { Name = "Medium", Heft = 500 };
            Size s3 = new Size() { Name = "Big", Heft = 900 };

            db.Ingredients.AddRange(new List<Ingredient> { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10 });
            db.SaveChanges();

            //Dish d1 = new Dish() { Name = "Paperoni" };
            d1.Ingredients.Add(i1);
            d1.Ingredients.Add(i2);
            d1.Ingredients.Add(i3);
            d1.Ingredients.Add(i4);
            d1.Ingredients.Add(i6);

            //Dish d2 = new Dish() { Name = "Kaltsone" };
            d2.Ingredients.Add(i1);
            d2.Ingredients.Add(i2);
            d2.Ingredients.Add(i5);
            d2.Ingredients.Add(i6);

            //Dish d3 = new Dish() { Name = "Margarita" };
            d3.Ingredients.Add(i1);
            d3.Ingredients.Add(i2);
            d3.Ingredients.Add(i3);
            d3.Ingredients.Add(i4);
            d3.Ingredients.Add(i7);
            d3.Ingredients.Add(i8);
            d3.Ingredients.Add(i9);

            db.Dishes.AddRange(new List<Dish> { d1, d2, d3 });
            db.SaveChanges();

            //Size s1 = new Size() { Name = "Small", Heft = 300 };
            //Size s2 = new Size() { Name = "Medium", Heft = 500 };
            //Size s3 = new Size() { Name = "Big", Heft = 900 };

            db.Sizes.AddRange(new List<Size> { s1, s2, s3 });
            db.SaveChanges();

            //Menu m1 = new Menu() { Price = 75 };
            m1.Dish = d1;
            m1.DishId = d1.Id;
            m1.Size = s1;
            m1.SizeId = s1.Id;

           // Menu m2 = new Menu() { Price = 120 };
            m2.Dish = d1;
            m2.DishId = d1.Id;
            m2.Size = s2;
            m2.SizeId = s2.Id;

            //Menu m3 = new Menu() { Price = 160 };
            m3.Dish = d1;
            m3.DishId = d1.Id;
            m3.Size = s3;
            m3.SizeId = s3.Id;

            //Menu m4 = new Menu() { Price = 66 };
            m4.Dish = d2;
            m4.DishId = d2.Id;
            m4.Size = s1;
            m4.SizeId = s1.Id;

            //Menu m5 = new Menu() { Price = 102 };
            m5.Dish = d2;
            m5.DishId = d2.Id;
            m5.Size = s2;
            m5.SizeId = s2.Id;

            //Menu m6 = new Menu() { Price = 138 };
            m6.Dish = d2;
            m6.DishId = d2.Id;
            m6.Size = s3;
            m6.SizeId = s3.Id;

            //Menu m7 = new Menu() { Price = 81 };
            m7.Dish = d3;
            m7.DishId = d3.Id;
            m7.Size = s1;
            m7.SizeId = s1.Id;

            //Menu m8 = new Menu() { Price = 134 };
            m8.Dish = d3;
            m8.DishId = d3.Id;
            m8.Size = s2;
            m8.SizeId = s2.Id;

            //Menu m9 = new Menu() { Price = 180 };
            m9.Dish = d3;
            m9.DishId = d3.Id;
            m9.Size = s3;
            m9.SizeId = s3.Id;

            db.MenuItems.AddRange(new List<Menu> { m1, m2, m3, m4, m5, m6, m7, m8, m9 });
            db.SaveChanges();
        }
    }
}
