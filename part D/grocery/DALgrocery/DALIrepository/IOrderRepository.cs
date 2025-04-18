﻿using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALrepository
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order GetById(int id);
        List<Order> GetAll();
        void Update(Order order);
        void Delete(int id);
    }
}
