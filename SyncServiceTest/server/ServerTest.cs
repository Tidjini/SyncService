using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SyncServiceTest.server
{
    /// <summary>
    /// Description résumée pour ServerTest
    /// </summary>
    [TestClass]
    public class ServerTest
    {
        private readonly DummyServer server; 
        public ServerTest()
        {
            server = new DummyServer();

        }


        [TestMethod]
        public void TestRunning()
        {
            server.Start();
            Assert.AreEqual(true, server.IsRunning);
        }
    }
}
