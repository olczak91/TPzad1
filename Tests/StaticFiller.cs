using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library;

namespace Tests
{
    public class StaticFiller : IFiller
    {
        public void FillData(DataContext dataContext)
        {
            Client c1 = new Client(0, "Marcin", "Stonoga", "stonoga@o2.pl", "93-254 Łódź, ul.Wszawa 4");
            Client c2 = new Client(1, "Michał", "Testowy", "test1@o2.pl", "91-254 Warszawa, ul.Szklana 45");
            Client c3 = new Client(2, "Marcin", "Stonoga", "stonoga@o2.pl", "48-424 Wrocław, ul.Kasztana 18");

            dataContext.Clients.Add(c1);
            dataContext.Clients.Add(c2);
            dataContext.Clients.Add(c3);

            Product p1 = new Product(0, "Visual Studio 2017 Express", "Microsoft", "Opis programu");
            Product p2 = new Product(1, "Windows XP", "Microsoft", "Opis systemu");
            Product p3 = new Product(2, "Notatnik", "NoName", "Opis programu");

            dataContext.Products.Add(p1.Id, p1);
            dataContext.Products.Add(p2.Id, p2);
            dataContext.Products.Add(p3.Id, p3);

            ProductVariant v1 = new ProductVariant(0, p1, 20, 99.99, "Nowy");
            ProductVariant v2 = new ProductVariant(1, p2, 5, 199.99, "Nowy");
            ProductVariant v3 = new ProductVariant(2, p2, 1, 18.29, "Używany");

            dataContext.ProductsVariants.Add(v1);
            dataContext.ProductsVariants.Add(v2);
            dataContext.ProductsVariants.Add(v3);

            Order o1 = new Order(0, v1, c1, 5, new DateTime(2010, 5, 12));
            Order o2 = new Order(1, v2, c1, 1, new DateTime(2010, 5, 12));
            Order o3 = new Order(2, v3, c2, 1, new DateTime(2011, 2, 22));
            Order o4 = new Order(3, v1, c1, 10, new DateTime(2011, 3, 2));
            Order o5 = new Order(4, v2, c3, 5, new DateTime(2012, 12, 19));

            dataContext.Orders.Add(o1);
            dataContext.Orders.Add(o2);
            dataContext.Orders.Add(o3);
            dataContext.Orders.Add(o4);
            dataContext.Orders.Add(o5);
        }
    }
}
