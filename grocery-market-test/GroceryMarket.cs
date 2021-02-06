using grocery_market.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace grocery_market_test
{
    [TestClass]
    public class GroceryMarket
    {
        [TestMethod]
        public void ScanItemsInOrder_ABCDABA()
        {
            decimal expected = 13.25m;

            var terminal = new PointOfSaleTerminal();
            //terminal.SetPricing();
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("A");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result, "Shopping cart not calculated the total correctly");
        }

        [TestMethod]
        public void ScanItemsInOrder_CCCCCCC()
        {
            decimal expected = 6.00m;

            var terminal = new PointOfSaleTerminal();
            //terminal.SetPricing();
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result, "Shopping cart not calculated the total correctly");
        }

        [TestMethod]
        public void ScanItemsInOrder_ABCD()
        {
            decimal expected = 7.25m;

            var terminal = new PointOfSaleTerminal();
            //terminal.SetPricing();
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");

            decimal result = terminal.CalculateTotal();
            Assert.AreEqual(expected, result, "Shopping cart not calculated the total correctly");
        }
    }
}
