﻿using SignalR.DatatAccessLayer.Abstract;
using SignalR.DatatAccessLayer.Concrete;
using SignalR.DatatAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DatatAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();

        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();

        }
    }
}