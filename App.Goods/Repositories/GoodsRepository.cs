using System;
using System.Collections.Generic;
using System.Text;
using App.Models;
using App.Repositories;

namespace App.Goods.Repositories
{
    public class GoodsRepository : IGodsRepository
    {
        static List<Good> goodsList;
        List<Order> orders = new List<Order>();
        static GoodsRepository()
        {
            goodsList = new List<Good> { new Good { Id = 1,Name = "Kaptsi", Price = 20 },
           new Good { Id = 2,Name = "Sapogi", Price = 25},
           new Good { Id = 3,Name = "Kufajka", Price = 2}};
        }
        public IEnumerable<Good> GetGoods()
        {
            return goodsList;
        }

        public void CreateOrder(Order order)
        {
            orders.Add(order);
        }
        public Good GetGood(int id)
        {
            return goodsList[id];
        }
    }
}
