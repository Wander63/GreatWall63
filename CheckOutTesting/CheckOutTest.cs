using CheckOutLib;

namespace CheckOutTesting
{
    public class CheckOutTest
    {
        private ICheckout checkout;
        [SetUp]
        public void Setup()
        {
            checkout=new Checkout(new List<char>());
        }

        [Test]
        public void ScanAddOneItem()
        {
            checkout.Scan("A");
            
            Assert.AreEqual(1, checkout.ScannedItemCount);
        }
        [Test]
        public void ScanAddThreeItems()
        {
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("D");
            Assert.AreEqual(3, checkout.ScannedItemCount);
        }


        [Test]
        public void ScanAddInvalidItems()
        {
            
            try
            {
                checkout.Scan("Abb");
                Assert.Fail("Invalid item name.");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
            }
        }

        [Test]
        public void ScanOneItemAndCheckPrice()
        {
            checkout.Scan("A");
            decimal totalPrice=checkout.GetTotalPrice();
            Assert.AreEqual(50M, totalPrice);
        }



    }
}