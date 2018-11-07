using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Order
    {
        public int Id { get; set; }
        public ProductVariant ProductVariant { get; set;}
        public Client Client { get; set; }
        public double Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(int id, ProductVariant productVariant, Client client, double quantity, DateTime orderDate)
        {
            Id = id;
            ProductVariant = productVariant;
            Client = client;
            Quantity = quantity;
            OrderDate = orderDate;
        }
        
        public override string ToString()
        {
            return string.Format("[{0}] {1} - {2} ({3} ; {4})", Id, ProductVariant.Id, Client.Id, Quantity, OrderDate);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Client)
            {
                Client clt = obj as Client;
                if (Id == clt.Id)
                    return true;
            }
            return false;
        }
    }
}
