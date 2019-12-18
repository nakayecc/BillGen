using System.Collections.Generic;
using BillShop;
using BillShop.DAO;
using BillShop.Services;
using NUnit.Framework;

namespace BillShopTest
{
    public class ProductRepo
    {
        [Test]
        public void GetCorrectListOfProduct()
        {
            var repository = new CsvProductRepository();


            var readProduct =
                repository.GetAll("C:\\Users\\48795\\RiderProjects\\BillShop\\BillShopTest\\ProductList.csv");
            var expectedProductList = new List<Product>
            {
                new Product(1001, "beer", 1.20,1),
                new Product(1243, "eggs", 0.20,1),
                new Product(3401, "chocolate", 3.15,1),
            };

            for (var i = 0; i < expectedProductList.Count; i++)
            {
                Assert.AreEqual(expectedProductList[i].Name, readProduct[i].Name);
                Assert.AreEqual(expectedProductList[i].Price, readProduct[i].Price);
                Assert.AreEqual(expectedProductList[i].BarCode, readProduct[i].BarCode);
            }
        }

        [Test]
        public void GetCorrectProductById()
        {
            var repository = new CsvProductRepository();

            var readProduct = repository.GetByBarcode(1001, "C:\\Users\\48795\\RiderProjects\\BillShop\\BillShopTest\\ProductList.csv");
            var expectedProduct = new Product(1001,"beer",1.20,1 );
            
            Assert.AreEqual(expectedProduct.BarCode,readProduct.BarCode);
            Assert.AreEqual(expectedProduct.Name,readProduct.Name);
            Assert.AreEqual(expectedProduct.Price,readProduct.Price);
        }

        [Test]

        public void ProductExist()
        {
            var productServices =
                new ProductService("C:\\Users\\48795\\RiderProjects\\BillShop\\BillShopTest\\ProductList.csv");
            
            Assert.AreEqual(true,productServices.ProductExist(1001));
        }
        
        [Test]
        public void ProductNotExist()
        {
            var productServices =
                new ProductService("C:\\Users\\48795\\RiderProjects\\BillShop\\BillShopTest\\ProductList.csv");
            
            Assert.AreEqual(false,productServices.ProductExist(10001));
        }
    }
}