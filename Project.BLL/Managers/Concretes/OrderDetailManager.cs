using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class OrderDetailManager : BaseManager<OrderDetail,OrderDetailDTO>, IOrderDetailManager
    {
        public OrderDetailManager(IRepository<OrderDetail> iRep) : base(iRep)
        {
        }
    }
}
