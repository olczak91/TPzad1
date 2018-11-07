using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public double QuantityAvailable { get; set; }
        public double Price { get; set; }
        public string VariantDescription { get; set; }

        public ProductVariant(int id, Product product, double quantityAvailable, double price, string variantDecription)
        {
            Id = id;
            Product = product;
            QuantityAvailable = quantityAvailable;
            Price = price;
            VariantDescription = variantDecription;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} [{2} - {3}] ({4})", Id, Product.Id, QuantityAvailable, Price, VariantDescription);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is ProductVariant)
            {
                ProductVariant vnt = obj as ProductVariant;
                if (Id == vnt.Id)
                    return true;
            }
            return false;
        }
    }
}
