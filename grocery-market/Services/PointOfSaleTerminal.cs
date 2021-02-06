using grocery_market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery_market.Services
{
    /// <summary>
    /// Represents a specfic point of sale which products can be added to a shopping cart as well as calculated.  
    /// This class cannot be inherited.
    /// </summary>
    public sealed class PointOfSaleTerminal : PointOfSale
    {
        const string product_doesnot_exist = "product does not exist";
        public PointOfSaleTerminal() : base()
        {

        }

        /// <summary>
        /// <see cref="PointOfSale.CalculateTotal"/>
        /// </summary>
        public override decimal CalculateTotal()
        {
            if ((ShoppingCart == null) || (!ShoppingCart.Any()))            
                return 0m;

            decimal pricePerUnit = ShoppingCart.Where(c => !c.Rules.Any()).Sum(c => c.Price);
            decimal pricePerVolum = 0m;
            
            foreach (var product in Products.Where(c => c.Rules.Any()).ToList())
            {
                if (ShoppingCart.Any(c => c.Name == product.Name))
                {
                    int productQuantity = ShoppingCart.Count(c => c.Name == product.Name);

                    // for appling the rule, the rule's quantity is going to be the priority
                    foreach (var rule in product.Rules.OrderByDescending(c => c.Quantity))
                    {
                        if (productQuantity < rule.Quantity)
                            continue;

                        int quantityPerVolume = productQuantity / rule.Quantity;
                        pricePerVolum += (quantityPerVolume * rule.VolumePrice);

                        productQuantity -= quantityPerVolume * rule.Quantity;
                    }

                    pricePerUnit += productQuantity * product.Price;
                }                
            }

            return pricePerUnit + pricePerVolum;
        }

        /// <summary>
        /// <see cref="PointOfSale.ScanProduct(string)"/>
        /// </summary>
        public override void ScanProduct(string nameProduct)
        {
            var product = Products.FirstOrDefault(c => c.Name.Equals(nameProduct, StringComparison.CurrentCulture));
            if (product != null)
            {
                ShoppingCart.Add(product);
            }
            else            
                throw new ArgumentOutOfRangeException($"{nameProduct} {product_doesnot_exist}");
        }

        /// <summary>
        /// <see cref="PointOfSale.ScanProduct(Product)"/>
        /// </summary>
        public override void ScanProduct(Product product)
        {
            var productFound = Products.FirstOrDefault(c => c.Name.Equals(product.Name, StringComparison.CurrentCulture));
            if (productFound != null)
            {
                ShoppingCart.Add(product);
            }
            else
                throw new ArgumentOutOfRangeException($"{product.Name} {product_doesnot_exist}");
        }

        /// <summary>
        /// <see cref="PointOfSale.SetPricing"/>
        /// </summary>
        public override void SetPricing()
        {
            throw new NotImplementedException("Method has not been specified");
        }
    }    
}

    
