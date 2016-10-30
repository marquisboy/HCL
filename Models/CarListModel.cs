using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCLProj.Models
{
    public class CarListModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public int CurrentPage { get; set; }
    }
}