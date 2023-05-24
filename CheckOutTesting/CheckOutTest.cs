using CheckOutLib;

namespace CheckOutTesting
{
    public class CheckOutTest
    {
        private ICheckout checkout;
        [SetUp]
        public void Setup()
        {
            checkout=new Checkout();
        }

        [Test]
        public void ScanAddOneItem()
        {
            checkout.Scan("A");
            
            Assert.AreEqual(1, checkout.ScannedItemCount);
        }
    }
}