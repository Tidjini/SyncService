using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyncService.models;

namespace SyncServiceTest
{
    [TestClass]
    public class ProductModelTest
    {
        [TestMethod]
        public void CanInitiateProduct()
        {

            Product product = new Product();
        }


        [TestMethod]
        public void ProductTypeTest()
        {
            Product product = new Product();

            Assert.AreEqual(typeof(string), product.Reference.GetType());
            Assert.AreEqual(typeof(string), product.Name.GetType());
            Assert.AreEqual(typeof(decimal), product.Montant.GetType());
            Assert.AreEqual(typeof(decimal), product.Qte.GetType());

        }
    }
}

