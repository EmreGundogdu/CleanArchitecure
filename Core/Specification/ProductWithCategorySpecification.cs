using Core.Entities;
using Core.Specification.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(string productName) : base(p => p.ProductName.ToLower().Contains(productName.ToLower()))
        {
            AddInclude(x => x.Category);
        }
        public ProductWithCategorySpecification() : base(null)
        {
            AddInclude(x => x.Category);
        }
    }
}
