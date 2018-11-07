using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DataContext
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public Dictionary<int, Product> Products { get; set; } = new Dictionary<int, Product>();
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        public ObservableCollection<ProductVariant> ProductsVariants { get; set; } = new ObservableCollection<ProductVariant>();

        internal DataContext()
        {
            // EMPTY
        }
    }
}
