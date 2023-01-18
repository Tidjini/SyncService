using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyncService.config;

namespace SyncServiceTest
{
    /// <summary>
    /// Description résumée pour NetworkTest
    /// </summary>
    [TestClass]
    public class NetworkTest
    {
        [TestMethod]
        public void IsAvailableTest()
        {
            var connectivity = Connectivity.IsAvailable;
            Assert.AreEqual(false, connectivity);
        }



    }
}
