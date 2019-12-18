using System.Collections.Generic;

namespace BillShop.DAO
{
    public interface IDiscount
    {
        Discount GetByBarcode(int barcode, string filePath);
        List<Discount> GetAll(string filename);
    }
}