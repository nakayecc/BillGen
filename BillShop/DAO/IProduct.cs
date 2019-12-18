using System.Collections.Generic;

namespace BillShop.DAO
{
    public interface IProduct
    {
        Product GetByBarcode(int barcode, string filePath);
        List<Product> GetAll(string filename);
    }
}