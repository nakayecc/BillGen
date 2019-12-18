using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BillShop.Services;

namespace BillShop.Controlers
{
    public class RootController
    {
        public BuyService BuyService { get; }
        
        public RootController()
        {
            BuyService = new BuyService("C:\\Users\\48795\\RiderProjects\\BillShop\\BillShop\\Data\\ProductList.csv",
                "C:\\Users\\48795\\RiderProjects\\BillShop\\BillShop\\Data\\Discountcsv.csv");
        }

        public void MakeBill(string[] args)
        {
            AddToBill(args);

            var needToPay = BuyService.BuyProductList.Sum(product => product.Value.Price);

            Console.WriteLine("Total price: " + Math.Round(needToPay,2));
        }

        private static IEnumerable<string> LoadBill(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Select(a => a.Split(','));
            return lines.Select(line => line[0]).ToList();
        }

        private void AddToBill(string[] bill)
        {
            foreach (var product in LoadBill(bill[0]))
            {
                BuyService.AddProduct(Convert.ToInt32(product));
            } 
        }
        
        
        
    }
}