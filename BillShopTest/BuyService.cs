using System.Collections.Generic;
using BillShop;
using NUnit.Framework;
using BillShop.Services;

namespace BillShopTest
{
    public class BuyService
    {
        [Test]
        public void AddProductToBasket()
        {
            var buyService =
                new BillShop.Services.BuyService(
                    "C:\\Users\\48795\\RiderProjects\\BillShop\\BillShopTest\\ProductList.csv",
                    "C:\\Users\\48795\\RiderProjects\\BillShop\\BillShop\\Data\\Discountcsv.csv"
                    );
            buyService.AddProduct(1001);

            var expected = new Dictionary<Product, int> {{new Product(1001, "beer", 1.20, 1), 1}};
            Assert.AreEqual(expected,buyService.BuyProductList);
        }
    }
}