using Microsoft.EntityFrameworkCore;
using SignalR.DatatAccessLayer.Abstract;
using SignalR.DatatAccessLayer.Concrete;
using SignalR.DatatAccessLayer.Repositories;
using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DatatAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();

            return context.Products.Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
            return values;
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecekler").Select(z => z.CategoryID).FirstOrDefault())).Count();
            return values;
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            var values = context.Products.Average(x => x.Price);
            return values;
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
            return values;
        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            var values = context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
            return values;
        }

        public decimal ProductAvgPriceByHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.Price);

        }

        public decimal ProductPriceBySteakBurger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.ProductName=="Steak Burger").Select(y=>y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCategory()
        {
            using var context = new SignalRContext();
            int id = context.Categories.Where(x => x.CategoryName == "İçecek").Select(y=>y.CategoryID).FirstOrDefault();
            return context.Products.Where(x=>x.CategoryID == id).Sum(y=>y.Price);

        }

        public decimal TotalPriceBySaladCategory()
        {
            using var context = new SignalRContext();
            int id = context.Categories.Where(x => x.CategoryName == "Salata").Select(y => y.CategoryID).FirstOrDefault();
            return context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
        }
    }
}