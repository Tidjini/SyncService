using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SyncServiceTest.server
{
    /// <summary>
    /// Description résumée pour ServerTest
    /// </summary>
    [TestClass]
    public class ServerTest
    {
        //private readonly DummyServer server; 
        public ServerTest()
        {
            

        }


        [TestMethod]
        public void TestRunning()
        {
            SyncService.communication.Service.OnConnect();

            SyncService.communication.Service.socket.On("hi", response =>
            {
                // You can print the returned data first to decide what to do next.
                // output: ["hi client"]
                string text = response.GetValue<string>();

                Assert.AreEqual(text, "hi there");


                // The socket.io server code looks like this:
                // socket.emit('hi', 'hi client');
            });

            
        }


        
    }
}
