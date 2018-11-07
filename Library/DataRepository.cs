using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DataRepository
    {
        protected DataContext DataContext = new DataContext();

        public DataRepository(IFiller filler)
        {
            filler.FillData(DataContext);
        }

        #region Client
        public void AddClient(Client client)
        {
            if (client != null)
                DataContext.Clients.Add(client);
        }
        public Client GetClientAtPosition(int position)
        {
            try
            {
                return DataContext.Clients[position];
            }
            catch (Exception)
            {
                // EMPTY
            }
            return null;
        }
        public Client GetClientById(int id)
        {
            return DataContext.Clients.First(x => x.Id == id);
        }
        public List<Client> GetAllClients()
        {
            return DataContext.Clients;
        }
        public void UpdateClientAtPosition(int position, Client newClientData)
        {
            try
            {
                Client client =  DataContext.Clients[position];
                if (client != null)
                {
                    client.Address = newClientData.Address;
                    client.Email = newClientData.Email;
                    client.Id = newClientData.Id;
                    client.Name = newClientData.Name;
                    client.Surname = newClientData.Surname;
                }
            }
            catch (Exception)
            {
                // EMPTY
            }
        }
        public void UpdateClientById(int id, Client newClientData)
        {
            Client client = DataContext.Clients.First(x => x.Id == id);
            if (client != null)
            {
                client.Address = newClientData.Address;
                client.Email = newClientData.Email;
                client.Name = newClientData.Name;
                client.Surname = newClientData.Surname;
            }
        }
        public void DeleteClientAtPosition(int position)
        {
            try
            {
                DataContext.Clients.RemoveAt(position);
            }
            catch (Exception)
            {
                // EMPTY
            }
        }
        public void DeleteClientById(int id)
        {
            Client client = DataContext.Clients.First(x => x.Id == id);
            if (client != null)
                DataContext.Clients.Remove(client);
        }
        #endregion
        
        #region Product
        public void AddProduct(Product product)
        {
            if (product != null && !DataContext.Products.ContainsKey(product.Id))
                DataContext.Products.Add(product.Id, product);
        }
        public Product GetProductById(int id)
        {
            try
            {
                return DataContext.Products[id];
            }
            catch(Exception)
            {
                // EMPTY
            }
            return null;
        }
        public Dictionary<int, Product> GetAllProducts()
        {
            return DataContext.Products;
        }
        public void UpdateProductById(int id, Product newProductData)
        {
            try
            {
                Product product = DataContext.Products[id];
                if (product != null)
                {
                    product.Description = newProductData.Description;
                    product.Manufacture = newProductData.Manufacture;
                    product.Name = newProductData.Name;
                }
            }
            catch (Exception)
            {
                // EMPTY
            }
        }
        public void DeleteProductById(int id)
        {
            try
            {
                DataContext.Products.Remove(id);
            }
            catch (Exception)
            {
                // EMPTY
            }
        }
        #endregion

        #region ProductVariant
        public void AddProductVariant(ProductVariant productVariant)
        {
            if (productVariant != null)
                DataContext.ProductsVariants.Add(productVariant);
        }
        public ProductVariant GetProductVariantAtPosition(int position)
        {
            try
            {
                return DataContext.ProductsVariants[position];
            }
            catch (Exception)
            {
                // EMPTY
            }
            return null;
        }
        public ProductVariant GetProductVariantById(int id)
        {
            return DataContext.ProductsVariants.First(x => x.Id == id);
        }
        public ObservableCollection<ProductVariant> GetAllProductVariants()
        {
            return DataContext.ProductsVariants;
        }
        public void UpdateProductVariantAtPosition(int position, ProductVariant newProductVariantData)
        {
            try
            {
                ProductVariant ProductVariant = DataContext.ProductsVariants[position];
                if (ProductVariant != null)
                {
                    ProductVariant.Id = newProductVariantData.Id;
                    ProductVariant.Price = newProductVariantData.Price;
                    ProductVariant.Product = newProductVariantData.Product;
                    ProductVariant.QuantityAvailable = newProductVariantData.QuantityAvailable;
                    ProductVariant.VariantDescription = newProductVariantData.VariantDescription;
                }
            }
            catch (Exception)
            {
                // EMPTY
            }
        }
        public void UpdateProductVariantById(int id, ProductVariant newProductVariantData)
        {
            ProductVariant ProductVariant = DataContext.ProductsVariants.First(x => x.Id == id);
            if (ProductVariant != null)
            {
                ProductVariant.Price = newProductVariantData.Price;
                ProductVariant.Product = newProductVariantData.Product;
                ProductVariant.QuantityAvailable = newProductVariantData.QuantityAvailable;
                ProductVariant.VariantDescription = newProductVariantData.VariantDescription;
            }
        }
        public void DeleteProductVariantAtPosition(int position)
        {
            try
            {
                DataContext.ProductsVariants.RemoveAt(position);
            }
            catch (Exception)
            {
                // EMPTY
            }
        }
        public void DeleteProductVariantById(int id)
        {
            ProductVariant ProductVariant = DataContext.ProductsVariants.First(x => x.Id == id);
            if (ProductVariant != null)
                DataContext.ProductsVariants.Remove(ProductVariant);
        }
        #endregion
        
        #region Order
        public void AddOrder(Order order)
        {
            if (order != null)
                DataContext.Orders.Add(order);
        }
        public Order GetOrderAtPosition(int position)
        {
            try
            {
                return DataContext.Orders[position];
            }
            catch (Exception)
            {
                // EMPTY
            }
            return null;
        }
        public Order GetOrderById(int id)
        {
            return DataContext.Orders.First(x => x.Id == id);
        }
        public ObservableCollection<Order> GetAllOrders()
        {
            return DataContext.Orders;
        }
        public void UpdateOrderAtPosition(int position, Order newOrderData)
        {
            try
            {
                Order order = DataContext.Orders[position];
                if (order != null)
                {
                    order.Client = newOrderData.Client;
                    order.Id = newOrderData.Id;
                    order.OrderDate = newOrderData.OrderDate;
                    order.ProductVariant = newOrderData.ProductVariant;
                    order.Quantity = newOrderData.Quantity;
                }
            }
            catch (Exception)
            {
                // EMPTY
            }
        }
        public void UpdateOrderById(int id, Order newOrderData)
        {
            Order order = DataContext.Orders.First(x => x.Id == id);
            if (order != null)
            {
                order.Client = newOrderData.Client;
                order.OrderDate = newOrderData.OrderDate;
                order.ProductVariant = newOrderData.ProductVariant;
                order.Quantity = newOrderData.Quantity;
            }
        }
        public void DeleteOrderAtPosition(int position)
        {
            try
            {
                DataContext.Orders.RemoveAt(position);
            }
            catch (Exception)
            {
                // EMPTY
            }
        }
        public void DeleteOrderById(int id)
        {
            Order order = DataContext.Orders.First(x => x.Id == id);
            if (order != null)
                DataContext.Orders.Remove(order);
        }
        #endregion
    }
}
