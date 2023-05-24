using CheckOutLib;

namespace CheckOutTesting
{
    public class CheckOutTest
    {
        private ICheckout checkout;
        [SetUp]
        public void Setup()
        {
            var itemCounts = new Dictionary<char, int>();
            var unitPrices = new Dictionary<char, decimal>
            {
                { 'A', 50 },
                { 'B', 30 },
                { 'C', 20 },
                { 'D', 15 }
            };
            Dictionary<char, Tuple<int, decimal>> specialPrices = new Dictionary<char, Tuple<int, decimal>>()
                {
                    {'A', new Tuple<int, decimal>(3, 130)},
                    {'B', new Tuple<int, decimal>(2, 45)}
                };
            checkout = new Checkout(unitPrices, itemCounts, specialPrices);
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
            decimal totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(50M, totalPrice);
        }

        [Test]
        public void ScanMultipleItemsAndCheckPrice()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            decimal totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(160M, totalPrice);
        }

        [Test]
        public void ScanMultipleItemsAndCheckPriceForSpecialOffer()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("C");
            checkout.Scan("A");

            decimal totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(150M, totalPrice);
        }

    }
}