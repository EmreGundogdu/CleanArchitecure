using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cart : Entity
    {
        public string Username { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public void AddItem(int productId, int quantity = 1, string color = "Black", decimal unitPrice = 0)
        {
            var existingItems = Items.FirstOrDefault(x => x.ProductId == productId);
            if (existingItems != null)
            {
                existingItems.Quantity++;
                existingItems.TotalPrice = existingItems.Quantity * existingItems.UnitPrice;

            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Color = color,
                    UnitPrice = unitPrice,
                    TotalPrice = quantity * unitPrice
                });
            }
        }
        public void RemoveItem(int cartItemId)
        {
            var removedItem = Items.FirstOrDefault(x=>x.Id == cartItemId);
        }
    }
}
