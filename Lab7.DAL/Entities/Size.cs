using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.DAL.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Heft { get; set; }
        public ICollection<Menu> Menus { get; set; }

        public Size()
        {
            Menus = new List<Menu>();
        }
    }
}
