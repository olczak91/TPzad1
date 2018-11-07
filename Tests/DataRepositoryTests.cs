using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Library;

namespace Tests
{
    [TestClass]
    public class DataRepositoryTests
    {
        #region -- Client ----------------------------------------------

        #region AddClient
        [TestMethod]
        public void AddClient()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetAllClients().Count, 3);
            Client client = new Client(5, "Test", "Test", "test@test.test", "00-000 Test, Testowa 0");
            rep.AddClient(client);
            Assert.AreEqual(rep.GetAllClients().Count, 4);
            Assert.AreEqual(rep.GetClientById(5), client);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddClient_ArgumentNull()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.AddClient(null);
        }
        #endregion

        #region GetClientAtPosition
        [TestMethod]
        public void GetClientAtPosition()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetClientAtPosition(0), rep.GetAllClients()[0]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetClientAtPosition_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.GetClientAtPosition(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetClientAtPosition_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.GetClientAtPosition(100);
        }
        #endregion

        #region GetClientById
        [TestMethod]
        public void GetClientById()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Client client = new Client(5, "Test", "Test", "test@test.test", "00-000 Test, Testowa 0");
            rep.AddClient(client);
            Assert.AreEqual(rep.GetClientById(5), client);
        }
        [TestMethod]
        public void GetClientById_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetClientById(-1), null);
        }
        [TestMethod]
        public void GetClientById_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetClientById(100), null);
        }
        #endregion

        #region GetAllClients
        [TestMethod]
        public void GetAllClients()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetAllClients().Count, 3);
            Client client = new Client(5, "Test", "Test", "test@test.test", "00-000 Test, Testowa 0");
            rep.AddClient(client);
            Assert.AreEqual(rep.GetAllClients().Count, 4);
        }
        #endregion

        #region UpdateClientAtPosition
        [TestMethod]
        public void UpdateClientAtPosition()
        {
            DataRepository rep = new DataRepository(new StaticFiller());

            Client newClient = new Client(5, "Test", "Test", "test@test.test", "00-000 Test, Testowa 0");
            Client client = rep.GetClientAtPosition(0);

            Assert.AreNotEqual(client.Address, newClient.Address);
            Assert.AreNotEqual(client.Email, newClient.Email);
            Assert.AreNotEqual(client.Id, newClient.Id);
            Assert.AreNotEqual(client.Name, newClient.Name);
            Assert.AreNotEqual(client.Surname, newClient.Surname);

            rep.UpdateClientAtPosition(0, newClient);

            Assert.AreEqual(client.Address, newClient.Address);
            Assert.AreEqual(client.Email, newClient.Email);
            Assert.AreEqual(client.Id, newClient.Id);
            Assert.AreEqual(client.Name, newClient.Name);
            Assert.AreEqual(client.Surname, newClient.Surname);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateClientAtPosition_ArgumentNull()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.UpdateClientAtPosition(0, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateClientAtPosition_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.UpdateClientAtPosition(-1, new Client(5, "Test", "Test", "test@test.test", "00-000 Test, Testowa 0"));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateClientAtPosition_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.UpdateClientAtPosition(100, new Client(5, "Test", "Test", "test@test.test", "00-000 Test, Testowa 0"));
        }
        #endregion

        #region UpdateClientById
        [TestMethod]
        public void UpdateClientById()
        {
            DataRepository rep = new DataRepository(new StaticFiller());

            Client newClient = new Client(5, "Test", "Test", "test@test.test", "00-000 Test, Testowa 0");
            Client client = rep.GetClientAtPosition(0);

            Assert.AreNotEqual(client.Address, newClient.Address);
            Assert.AreNotEqual(client.Email, newClient.Email);
            Assert.AreNotEqual(client.Name, newClient.Name);
            Assert.AreNotEqual(client.Surname, newClient.Surname);
            Assert.AreNotEqual(client.Id, newClient.Id);

            Assert.AreEqual(rep.UpdateClientById(0, newClient), true);

            Assert.AreEqual(client.Address, newClient.Address);
            Assert.AreEqual(client.Email, newClient.Email);
            Assert.AreEqual(client.Name, newClient.Name);
            Assert.AreEqual(client.Surname, newClient.Surname);
            Assert.AreNotEqual(client.Id, newClient.Id);
        }
        [TestMethod]
        public void UpdateClientById_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Client newClient = new Client(5, "Test", "Test", "test@test.test", "00-000 Test, Testowa 0");
            Assert.AreEqual(rep.UpdateClientById(-1, newClient), false);
        }
        [TestMethod]
        public void UpdateClientById_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Client newClient = new Client(5, "Test", "Test", "test@test.test", "00-000 Test, Testowa 0");
            Assert.AreEqual(rep.UpdateClientById(100, newClient), false);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateClientById_ArgumentNull()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.UpdateClientById(0, null);
        }
        #endregion

        #region DeleteClientAtPosition
        [TestMethod]
        public void DeleteClientAtPosition()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetAllClients().Count, 3);
            int idToDelete = rep.GetClientAtPosition(0).Id;
            rep.DeleteClientAtPosition(0);
            Assert.AreEqual(rep.GetAllClients().Count, 2);
            Assert.AreEqual(rep.GetClientById(idToDelete), null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteClientAtPosition_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.DeleteClientAtPosition(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteClientAtPosition_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.DeleteClientAtPosition(100);
        }
        #endregion

        #region DeleteClientById
        [TestMethod]
        public void DeleteClientById()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetAllClients().Count, 3);
            Assert.AreEqual(rep.DeleteClientById(0), true);
            Assert.AreEqual(rep.GetAllClients().Count, 2);
            Assert.AreEqual(rep.GetClientById(0), null);
        }
        [TestMethod]
        public void DeleteClientById_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.DeleteClientById(-1), false);
        }
        [TestMethod]
        public void DeleteClientById_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.DeleteClientById(100), false);
        }
        #endregion

        #endregion

        #region -- Product ---------------------------------------------

        #endregion


        #region -- Product Variant ----------------------------------------------

        #region AddProductVariant
        [TestMethod]
        public void AddProductVariant()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetAllProductVariants().Count, 3);
            Product product = new Product(5, "Test", "Test", "Test");
            ProductVariant productVariant = new ProductVariant(5, product, 3.0, 30.0, "Test");
            rep.AddProductVariant(productVariant);
            Assert.AreEqual(rep.GetAllProductVariants().Count, 4);
            Assert.AreEqual(rep.GetProductVariantById(5), productVariant);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddProductVariant_ArgumentNull()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.AddProductVariant(null);
        }
        #endregion

        #region GetProductVariantAtPosition
        [TestMethod]
        public void GetProductVariantAtPosition()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetProductVariantAtPosition(0), rep.GetAllProductVariants()[0]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetProductVariantAtPosition_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.GetProductVariantAtPosition(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetProductVariantAtPosition_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.GetProductVariantAtPosition(100);
        }
        #endregion

        #region GetProductVariantById
        [TestMethod]
        public void GetProductVariantById()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Product product = new Product(5, "Test", "Test", "Test");
            ProductVariant productVariant = new ProductVariant(5, product, 3.0, 30.0, "Test");
            rep.AddProductVariant(productVariant);
            Assert.AreEqual(rep.GetProductVariantById(5), productVariant);
        }
        [TestMethod]
        public void GetProductVariantById_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetProductVariantById(-1), null);
        }
        [TestMethod]
        public void GetProductVariantById_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetProductVariantById(100), null);
        }
        #endregion

        #region GetAllProductVariants
        [TestMethod]
        public void GetAllProductVariants()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetAllProductVariants().Count, 3);
            Product product = new Product(5, "Test", "Test", "Test");
            ProductVariant productVariant = new ProductVariant(5, product, 3.0, 30.0, "Test");
            rep.AddProductVariant(productVariant);
            Assert.AreEqual(rep.GetAllProductVariants().Count, 4);
        }
        #endregion

        #region UpdateProductVariantAtPosition
        [TestMethod]
        public void UpdateProductVariantAtPosition()
        {
            DataRepository rep = new DataRepository(new StaticFiller());

            Product product = new Product(5, "Test", "Test", "Test");
            ProductVariant newProductVariant = new ProductVariant(5, product, 3.0, 30.0, "Test");
            ProductVariant productVariant = rep.GetProductVariantAtPosition(0);

            Assert.AreNotEqual(productVariant.Price, newProductVariant.Price);
            Assert.AreNotEqual(productVariant.Product, newProductVariant.Product);
            Assert.AreNotEqual(productVariant.Id, newProductVariant.Id);
            Assert.AreNotEqual(productVariant.QuantityAvailable, newProductVariant.QuantityAvailable);
            Assert.AreNotEqual(productVariant.VariantDescription, newProductVariant.VariantDescription);

            rep.UpdateProductVariantAtPosition(0, newProductVariant);

            Assert.AreEqual(productVariant.Price, newProductVariant.Price);
            Assert.AreEqual(productVariant.Product, newProductVariant.Product);
            Assert.AreEqual(productVariant.Id, newProductVariant.Id);
            Assert.AreEqual(productVariant.QuantityAvailable, newProductVariant.QuantityAvailable);
            Assert.AreEqual(productVariant.VariantDescription, newProductVariant.VariantDescription);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateProductVariantAtPosition_ArgumentNull()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.UpdateProductVariantAtPosition(0, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateProductVariantAtPosition_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Product product = new Product(5, "Test", "Test", "Test");
            ProductVariant productVariant = new ProductVariant(5, product, 3.0, 30.0, "Test");
            rep.UpdateProductVariantAtPosition(-1, productVariant);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateProductVariantAtPosition_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Product product = new Product(5, "Test", "Test", "Test");
            ProductVariant productVariant = new ProductVariant(5, product, 3.0, 30.0, "Test");
            rep.UpdateProductVariantAtPosition(100, productVariant);
        }
        #endregion

        #region UpdateProductVariantById
        [TestMethod]
        public void UpdateProductVariantById()
        {
            DataRepository rep = new DataRepository(new StaticFiller());

            Product product = new Product(5, "Test", "Test", "Test");
            ProductVariant newProductVariant = new ProductVariant(5, product, 3.0, 30.0, "Test");
            ProductVariant productVariant = rep.GetProductVariantAtPosition(0);

            Assert.AreNotEqual(productVariant.Price, newProductVariant.Price);
            Assert.AreNotEqual(productVariant.Product, newProductVariant.Product);
            Assert.AreNotEqual(productVariant.QuantityAvailable, newProductVariant.QuantityAvailable);
            Assert.AreNotEqual(productVariant.VariantDescription, newProductVariant.VariantDescription);
            Assert.AreNotEqual(productVariant.Id, newProductVariant.Id);

            Assert.AreEqual(rep.UpdateProductVariantById(0, newProductVariant), true);

            Assert.AreEqual(productVariant.Price, newProductVariant.Price);
            Assert.AreEqual(productVariant.Product, newProductVariant.Product);
            Assert.AreEqual(productVariant.QuantityAvailable, newProductVariant.QuantityAvailable);
            Assert.AreEqual(productVariant.VariantDescription, newProductVariant.VariantDescription);
            Assert.AreNotEqual(productVariant.Id, newProductVariant.Id);
        }
        [TestMethod]
        public void UpdateProductVariantById_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Product product = new Product(5, "Test", "Test", "Test");
            ProductVariant productVariant = new ProductVariant(5, product, 3.0, 30.0, "Test");
            Assert.AreEqual(rep.UpdateProductVariantById(-1, productVariant), false);
        }
        [TestMethod]
        public void UpdateProductVariantById_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Product product = new Product(5, "Test", "Test", "Test");
            ProductVariant productVariant = new ProductVariant(5, product, 3.0, 30.0, "Test");
            Assert.AreEqual(rep.UpdateProductVariantById(100, productVariant), false);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateProductVariantById_ArgumentNull()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.UpdateProductVariantById(0, null);
        }
        #endregion

        #region DeleteProductVariantAtPosition
        [TestMethod]
        public void DeleteProductVariantAtPosition()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetAllProductVariants().Count, 3);
            int idToDelete = rep.GetProductVariantAtPosition(0).Id;
            rep.DeleteProductVariantAtPosition(0);
            Assert.AreEqual(rep.GetAllProductVariants().Count, 2);
            Assert.AreEqual(rep.GetProductVariantById(idToDelete), null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteProductVariantAtPosition_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.DeleteProductVariantAtPosition(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteProductVariantAtPosition_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            rep.DeleteProductVariantAtPosition(100);
        }
        #endregion

        #region DeleteProductVariantById
        [TestMethod]
        public void DeleteProductVariantById()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.GetAllProductVariants().Count, 3);
            Assert.AreEqual(rep.DeleteProductVariantById(0), true);
            Assert.AreEqual(rep.GetAllProductVariants().Count, 2);
            Assert.AreEqual(rep.GetProductVariantById(0), null);
        }
        [TestMethod]
        public void DeleteProductVariantById_ArgumentOutOfRange_Smaller()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.DeleteProductVariantById(-1), false);
        }
        [TestMethod]
        public void DeleteProductVariantById_ArgumentOutOfRange_Bigger()
        {
            DataRepository rep = new DataRepository(new StaticFiller());
            Assert.AreEqual(rep.DeleteProductVariantById(100), false);
        }
        #endregion

        #endregion
    }
}
