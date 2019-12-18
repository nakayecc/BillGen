using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BillShop.DAO
{
    public class CsvDiscountRepository : IDiscount
    {
        public Discount GetByBarcode(int barcode, string filePath)
        {
            var discounts = GetAll(filePath);

            return discounts
                .FirstOrDefault(discount => discount.Barcode == barcode);
        }

        public List<Discount> GetAll(string filePath)
        {
            const int barCode = 0;
            const int amount = 1;
            const int discountValue = 2;


            var lines = File.ReadAllLines(filePath).Select(a => a.Split(','));
            return lines.Select(line => new Discount(
                    Convert.ToInt32(line[barCode]),
                    Convert.ToInt32(line[amount]),
                    Convert.ToDouble(line[discountValue].Replace(".", ",")))
                )
                .ToList();
        }
    }
}