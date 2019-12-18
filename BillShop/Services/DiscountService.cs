using System.Collections.Generic;
using System.Linq;
using BillShop.DAO;

namespace BillShop.Services
{
    public class DiscountService
    {
        public IDiscount Discount { get; }

        public List<Discount> DiscountList { get; set; }


        public DiscountService(string discountFilePath)
        {
            DiscountList = new List<Discount>();
            Discount = new CsvDiscountRepository();
            DiscountList = Discount.GetAll(discountFilePath);
            
        }
        public Discount GetDiscount(int barcode)
        {
            return DiscountList.FirstOrDefault(discount => discount.Barcode == barcode);
        }
    }
}