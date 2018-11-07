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
            else
                throw new ArgumentNullException();
        }
        public Client GetClientAtPosition(int position)
        {
            // throws ArgumentOutOfRangeException
            return DataContext.Clients[position];
        }
        public Client GetClientById(int id)
        {
            if (DataContext.Clients.Exists(x => x.Id == id))
                return DataContext.Clients.First(x => x.Id == id);
            else
                return null;
        }
        public List<Client> GetAllClients()
        {
            return DataContext.Clients;
        }
        public void UpdateClientAtPosition(int position, Client newClientData)
        {
            if (newClientData != null)
            {
                // throws ArgumentOutOfRangeException
                Client client = DataContext.Clients[position];
                if (client != null)
                {
                    client.Address = newClientData.Address;
                    client.Email = newClientData.Email;
                    client.Id = newClientData.Id;
                    client.Name = newClientData.Name;
                    client.Surname = newClientData.Surname;
                }
                else
                    throw new NullReferenceException();
            }
            else
                throw new ArgumentNullException();
        }
        public bool UpdateClientById(int id, Client newClientData)
        {
            if (newClientData != null)
            {
                if (DataContext.Clients.Exists(x => x.Id == id))
                {
                    Client client = DataContext.Clients.First(x => x.Id == id);
                    client.Address = newClientData.Address;
                    client.Email = newClientData.Email;
                    client.Name = newClientData.Name;
                    client.Surname = newClientData.Surname;
                    return true;
                }
                return false;
            }
            else
                throw new ArgumentNullException();
        }
        public void DeleteClientAtPosition(int position)
        {
            // throws ArgumentOutOfRangeException
            DataContext.Clients.RemoveAt(position);
        }
        public bool DeleteClientById(int id)
        {
            if (DataContext.Clients.Exists(x => x.Id == id))
            {
                Client client = DataContext.Clients.First(x => x.Id == id);
                return DataContext.Clients.Remove(client);
            }
            return false;
        }
        #endregion
        
        #region Product
        public void AddProduct(Product product)
        {
            if (product != null)
            {
                // throws ArgumentException if duplicated key
                DataContext.Products.Add(product.Id, product);
            }
            else
                throw new ArgumentNullException();
        }
        public Product GetProductById(int id)
        {
            // throws KeyNotFoundException
            return DataContext.Products[id];
        }
        public Dictionary<int, Product> GetAllProducts()
        {
            return DataContext.Products;
        }
        public void UpdateProductById(int id, Product newProductData)
        {
            if (newProductData != null)
            {
                // throws KeyNotFoundException
                Product product = DataContext.Products[id];
                if (product != null)
                {
                    product.Description = newProductData.Description;
                    product.Manufacture = newProductData.Manufacture;
                    product.Name = newProductData.Name;
                }
                else
                    throw new NullReferenceException();
            }
            else
                throw new ArgumentNullException();
        }
        public bool DeleteProductById(int id)
        {
            return DataContext.Products.Remove(id);
        }
        #endregion

        #region ProductVariant
        public void AddProductVariant(ProductVariant productVariant)
        {
            if (productVariant != null)
                DataContext.ProductsVariants.Add(productVariant);
            else
                throw new ArgumentNullException();
        }
        public ProductVariant GetProductVariantAtPosition(int position)
        {
            // throws ArgumentOutOfRangeException
            return DataContext.ProductsVariants[position];
        }
        public ProductVariant GetProductVariantById(int id)
        {
            if (DataContext.ProductsVariants.Any(x => x.Id == id))
                return DataContext.ProductsVariants.First(x => x.Id == id);
            else
                return null;
        }
        public ObservableCollection<ProductVariant> GetAllProductVariants()
        {
            return DataContext.ProductsVariants;
        }
        public void UpdateProductVariantAtPosition(int position, ProductVariant newProductVariantData)
        {
            if (newProductVariantData != null)
            {
                // throws ArgumentOutOfRangeException
                ProductVariant productVariant = DataContext.ProductsVariants[position];
                if (productVariant != null)
                {
                    productVariant.Id = newProductVariantData.Id;
                    productVariant.Price = newProductVariantData.Price;
                    productVariant.Product = newProductVariantData.Product;
                    productVariant.QuantityAvailable = newProductVariantData.QuantityAvailable;
                    productVariant.VariantDescription = newProductVariantData.VariantDescription;
                }
                else
                    throw new NullReferenceException();
            }
            else
                throw new ArgumentNullException();
        }
        public bool UpdateProductVariantById(int id, ProductVariant newProductVariantData)
        {
            if (newProductVariantData != null)
            {
                if (DataContext.ProductsVariants.Any(x => x.Id == id))
                {
                    ProductVariant productVariant = DataContext.ProductsVariants.First(x => x.Id == id);
                    productVariant.Price = newProductVariantData.Price;
                    productVariant.Product = newProductVariantData.Product;
                    productVariant.QuantityAvailable = newProductVariantData.QuantityAvailable;
                    productVariant.VariantDescription = newProductVariantData.VariantDescription;
                    return true;
                }
                return false;
            }
            else
                throw new ArgumentNullException();
        }
        public void DeleteProductVariantAtPosition(int position)
        {
            // throws ArgumentOutOfRangeException
            DataContext.ProductsVariants.RemoveAt(position);
        }
        public bool DeleteProductVariantById(int id)
        {
            if (DataContext.ProductsVariants.Any(x => x.Id == id))
            {
                ProductVariant ProductVariant = DataContext.ProductsVariants.First(x => x.Id == id);
                return DataContext.ProductsVariants.Remove(ProductVariant);
            }
            return false;
        }
        #endregion
        
        #region Order
        public void AddOrder(Order order)
        {
            if (order != null)
                DataContext.Orders.Add(order);
            else
                throw new ArgumentNullException();
        }
        public Order GetOrderAtPosition(int position)
        {
            // throws ArgumentOutOfRangeException
            return DataContext.Orders[position];
        }
        public Order GetOrderById(int id)
        {
            if (DataContext.Orders.Any(x => x.Id == id))
                return DataContext.Orders.First(x => x.Id == id);
            else
                return null;
        }
        public ObservableCollection<Order> GetAllOrders()
        {
            return DataContext.Orders;
        }
        public void UpdateOrderAtPosition(int position, Order newOrderData)
        {
            if (newOrderData != null)
            {
                // throws ArgumentOutOfRangeException
                Order order = DataContext.Orders[position];
                if (order != null)
                {
                    order.Client = newOrderData.Client;
                    order.Id = newOrderData.Id;
                    order.OrderDate = newOrderData.OrderDate;
                    order.ProductVariant = newOrderData.ProductVariant;
                    order.Quantity = newOrderData.Quantity;
                }
                else
                    throw new NullReferenceException();
            }
            else
                throw new ArgumentNullException();
        }
        public bool UpdateOrderById(int id, Order newOrderData)
        {
            if (newOrderData != null)
            {
                if (DataContext.Orders.Any(x => x.Id == id))
                {
                    Order order = DataContext.Orders.First(x => x.Id == id);
                    order.Client = newOrderData.Client;
                    order.OrderDate = newOrderData.OrderDate;
                    order.ProductVariant = newOrderData.ProductVariant;
                    order.Quantity = newOrderData.Quantity;
                    return true;
                }
                return false;
            }
            else
                throw new ArgumentNullException();
        }
        public void DeleteOrderAtPosition(int position)
        {
            // throws ArgumentOutOfRangeException
            DataContext.Orders.RemoveAt(position);
        }
        public bool DeleteOrderById(int id)
        {
            if (DataContext.Orders.Any(x => x.Id == id))
            {
                Order order = DataContext.Orders.First(x => x.Id == id);
                return DataContext.Orders.Remove(order);
            }
            return false;
        }
        #endregion
    }
}
