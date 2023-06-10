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
                { 'D', 15 },
                {'&', 5 }
            };

            Dictionary<char, Tuple<int, decimal>> specialPrices = new Dictionary<char, Tuple<int, decimal>>()
                {
                    {'A', new Tuple<int, decimal>(3, 130)},
                    {'B', new Tuple<int, decimal>(2, 45)},
                 {'&', new Tuple<int, decimal>(5, 5)}
                };
            checkout = new Checkout(unitPrices, itemCounts, specialPrices);
        }

        [Test]
        public void ScanAddOneItem()
        {
            checkout.Scan("A");
            decimal totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(55, totalPrice);
        }
        [Test]
        public void ScanAddThreeItems()
        {
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("D");
            decimal totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(110, totalPrice);
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
            Assert.AreEqual(55M, totalPrice);
        }

        [Test]
        public void ScanMultipleItemsAndCheckPrice()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            decimal totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(180M, totalPrice);
        }

        [Test]
        public void ScanMultipleItemsAndCheckPriceForSpecialOffer()
        {
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("C");
            checkout.Scan("A");

            decimal totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(170M, totalPrice);
        }

        [Test]
        public void ScanMultipleItemsAndSpecialOfferFinalTesting()
        {
            // Scan items
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");
            checkout.Scan("A");
            checkout.Scan("B");

            decimal totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(190M, totalPrice);
        }


    }
}