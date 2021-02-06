using grocery_market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery_market.Services
{
    /// <summary>
    /// Represents a general point of sale, which has everything necessary in order that other points of sale operate under their own business logic.
    /// If a new point of sale wants to be added, it must inherit this class
    /// </summary>
    public abstract class PointOfSale
    {
        public PointOfSale()
        {
            LoadProducts();
            ShoppingCart = new List<Product>();
        }

        /// <summary>
        /// Scaned products 
        /// </summary>        
        public List<Product> ShoppingCart { get; set; }

        private static HashSet<Product> _products;
        /// <summary>
        /// produts by default
        /// it is a <see cref="HashSet{T}"></see> collection since it is neccesary be sure that each product is unique />
        /// </summary>
        public static ICollection<Product> Products
        {
            get
            {
                return _products ??
                    (_products = new HashSet<Product>());
            }
            set { _products = new HashSet<Product>(value); }
        }

        /// <summary>
        /// Sets the produc's price
        /// </summary>
        /// Exceptions:
        /// T:<see cref="NotImplementedException"/>
        ///     Method could not have implementation.
        public abstract void SetPricing();

        /// <summary>
        /// Adds a new product to the shopping cart
        /// </summary>
        /// <param name="nameProduct">name of the product to the shopping cart</param>
        /// Exceptions:
        /// T:<see cref="ArgumentOutOfRangeException"/>
        ///     A product name could not exist.
        public abstract void ScanProduct(string nameProduct);

        /// <summary>
        /// Adds a new product to the shopping cart
        /// </summary>
        /// <param name="product">product to be added to the shopping cart</param>
        /// Exceptions:
        /// T:<see cref="ArgumentOutOfRangeException"/>
        ///     A product name could not exist.
        public abstract void ScanProduct(Product product);

        /// <summary>
        /// calculates the products total price which were added to the shopping cart
        /// </summary>
        /// <returns>Returns the total price </returns>
        public abstract decimal CalculateTotal();

        /// <summary>
        /// Loads the whole products and their rules
        /// </summary>
        public virtual void LoadProducts()
        {
            Products.Add(new Product() { Name = "A", Price = 1.25m, Rules = { new Rule() { Quantity = 3, VolumePrice = 3.00m } } });
            Products.Add(new Product() { Name = "B", Price = 4.25m });
            Products.Add(new Product() { Name = "C", Price = 1.00m, Rules = { new Rule() { Quantity = 6, VolumePrice = 5.00m } } });
            Products.Add(new Product() { Name = "D", Price = 0.75m });
        }
    }
}
