﻿using Project.BLL.DTOClasses.Concretes;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IOrderManager : IMapper<Order,OrderDTO>
    {
    }
}
