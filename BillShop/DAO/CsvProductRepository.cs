using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BillShop.DAO
{
    public class CsvProductRepository : IProduct
    {
        public Product GetByBarcode(int barcode, string filePath)
        {
            var products = GetAll(filePath);

            return products
                .FirstOrDefault(product => product.BarCode == barcode);
        }

        public List<Product> GetAll(string filePath)
        {
            const int barCode = 0;
            const int name = 1;
            const int price = 2;


            var lines = File.ReadAllLines(filePath).Select(a => a.Split(','));
            return lines.Select(line => new Product(
                    Convert.ToInt32(line[barCode]),
                    line[name].ToString(),
                    Convert.ToDouble(line[price].Replace(".", ","))))
                .ToList();



        }
    }
}