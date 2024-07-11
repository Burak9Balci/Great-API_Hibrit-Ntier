using Project.BLL.DTOClasses.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTOClasses.Concretes
{
    public abstract class BaseDTO : IDTO
    {
        public int ID { get; set; }
    }
}
