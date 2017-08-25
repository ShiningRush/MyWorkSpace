using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkSpace.MPA.Models
{
    public class MenuModel
    {
        public string MenuText { get; set; }
        public string Url { get; set; }
        public string IconStr { get; set; }
        public List<MenuModel> ChildItem { get; set; }
    }
}
