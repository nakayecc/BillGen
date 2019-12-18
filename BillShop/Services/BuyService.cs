using System;
using System.Collections.Generic;

namespace BillShop.Services
{
    public class BuyService
    {
        public Dictionary<int, Product> BuyProductList { get; }
        public Dictionary<int, int> DiscountDictionary { get;}
        public ProductService ProductService { get; }
        public DiscountService DiscountService { get; }

        public BuyService(string productFilePath, string discountFilePath)
        {
            DiscountService = new DiscountService(discountFilePath);
            DiscountDictionary = new Dictionary<int, int>();
            ProductService = new ProductService(productFilePath);
            BuyProductList = new Dictionary<int, Product>();
        }

        public void AddProduct(int barcode)
        {
            if (!ProductService.ProductExist(barcode)) return;

            if (DiscountDictionary.ContainsKey(barcode))
            {
                CheckDiscount(barcode);
            }
            else
            {
                if (BuyProductList.ContainsKey(barcode))
                {
                    BuyProductList[barcode].Amount += 1;
                    BuyProductList[barcode].Price += ProductService.GetProduct(barcode).Price;
                    DiscountDictionary.Add(barcode, 1);
                }
                else
                {
                    BuyProductList.Add(barcode, ProductService.GetProduct(barcode));
                    DiscountDictionary.Add(barcode, 1);
                }
            }
        }

        private void CheckDiscount(int barcode)
        {
            if (!DiscountService.DiscountList.Contains(DiscountService.GetDiscount(barcode)))
            {
                AddNormalProduct(barcode);
                return;
            }
            if ((DiscountDictionary[barcode]) == DiscountService.GetDiscount(barcode).Amount - 1)
            {
                AddDiscountedProduct(barcode);
            }
            else
            {
                AddNormalProduct(barcode);
            }
        }

        private void AddNormalProduct(int barcode)
        {
            BuyProductList[barcode].Amount += 1;
            BuyProductList[barcode].Price += ProductService.GetProduct(barcode).Price;
            DiscountDictionary[barcode] += 1;
        }

        private void AddDiscountedProduct(int barcode)
        {
            var discountProduct = ProductService.GetProduct(barcode);
            discountProduct.Price -= DiscountService.GetDiscount(barcode).DiscountValue;

            BuyProductList[barcode].Amount += 1;
            BuyProductList[barcode].Price += discountProduct.Price;
            DiscountDictionary.Remove(barcode);
        }
    }
}