using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.BLL.DTO
{
    public class SizeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Heft { get; set; }
        public ICollection<MenuDTO> Menus { get; set; }

        public SizeDTO()
        {
            Menus = new List<MenuDTO>();
        }
    }
}
