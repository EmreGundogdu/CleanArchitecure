using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AspNetRunContextSeed
    {
        public static async Task SeedAsync(AspNetRunContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(GetPreconfiguredCategories());
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(GetProconfiguredProducts());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AspNetRunContextSeed>();
                    log.LogError(e.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>
            {
                new Category(){CategoryName="Phone"},
                new Category(){CategoryName="TV"},
            };
        }
        private static IEnumerable<Product> GetProconfiguredProducts()
        {
            return new List<Product>
            {
                new Product(){ProductName="IPhone",CategoryId=1,UnitPrice=19.5m,UnitsInStock=10,QuantityPerUnit="2",UnitsOnOrder=1,ReorderLevel=1,Discontinued=false},
                new Product(){ProductName="Samsung",CategoryId=1,UnitPrice=33.5m,UnitsInStock=10,QuantityPerUnit="2",UnitsOnOrder=1,ReorderLevel=1,Discontinued=false},
                new Product(){ProductName="LG TV",CategoryId=2,UnitPrice=33.5m,UnitsInStock=10,QuantityPerUnit="2",UnitsOnOrder=1,ReorderLevel=1,Discontinued=false},
            };
        }
    }
}
